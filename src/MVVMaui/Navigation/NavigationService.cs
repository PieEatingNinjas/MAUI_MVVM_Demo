using MVVMaui.Contracts.Navigation;
using System.Diagnostics;

namespace MVVMaui.Navigation
{
    public class NavigationService : INavigationService
    {
        internal static IDictionary<string, Type> Registrations { get; } = new Dictionary<string, Type>();

        readonly IServiceProvider _services;

        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }

        public Task Navigate(string name, object? parameter = null)
            => NavigateToPage(name, parameter);

        public NavigationService(IServiceProvider services)
            => _services = services;

        public Task NavigateBack()
        {
            if (Navigation.NavigationStack.Count > 1)
                return Navigation.PopAsync();

            throw new InvalidOperationException("No pages to navigate back to!");
        }

        private async Task NavigateToPage(Page toPage, object? parameter)
        {
            //Subscribe to the toPage's NavigatedTo event
            toPage.NavigatedTo += Page_NavigatedTo;

            //Get VM of the toPage
            var toViewModel = GetPageViewModel<IOnNavigatingToAware>(toPage);

            //Call navigatingTo on VM, passing in the paramter
            if (toViewModel is not null)
                await toViewModel.OnNavigatingTo(parameter);

            //Navigate to requested page
            await Navigation.PushAsync(toPage, true);

            //Subscribe to the toPage's NavigatedFrom event
            toPage.NavigatedFrom += Page_NavigatedFrom;
        }

        private Task NavigateToPage(string name, object? parameter = null)
        {
            var registration = Registrations[name];
            var page = _services.GetService(registration);

            if (page is Page toPage)
            {
                return NavigateToPage(toPage, parameter);
            }
            else
                throw new InvalidOperationException($"Unable to resolve type {name}");

        }

        private async void Page_NavigatedFrom(object? sender, NavigatedFromEventArgs e)
        {
            //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
            //If that entry equals the sender, it means we navigated forward from the sender to another page
            bool isForwardNavigation = Navigation.NavigationStack.Count > 1
                && Navigation.NavigationStack[^2] == sender;

            if (sender is Page thisPage)
            {
                if (!isForwardNavigation)
                {
                    thisPage.NavigatedTo -= Page_NavigatedTo;
                    thisPage.NavigatedFrom -= Page_NavigatedFrom;
                }

                await CallNavigatedFrom(thisPage, isForwardNavigation);
            }
        }

        private Task CallNavigatedFrom(Page p, bool isForward)
        {
            var fromViewModel = GetPageViewModel<IOnNavigatedFromAware>(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedFrom(isForward);
            return Task.CompletedTask;
        }

        private async void Page_NavigatedTo(object? sender, NavigatedToEventArgs e)
            => await CallNavigatedTo(sender as Page);

        private Task CallNavigatedTo(Page? p)
        {
            var fromViewModel = GetPageViewModel<IOnNavigatedToAware>(p);

            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedTo();
            return Task.CompletedTask;
        }

        private T? GetPageViewModel<T>(Page? p) where T : class
            => p?.BindingContext as T;
    }
}
