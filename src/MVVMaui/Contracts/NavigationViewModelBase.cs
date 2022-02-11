using MVVMaui.Contracts.Navigation;

namespace MVVMaui.Contracts
{
    public abstract class NavigationViewModelBase : ViewModelBase
    {
        protected readonly INavigationService _navigationService;

        public NavigationViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected Task Navigate(string name, object? parameter = null)
            => _navigationService.Navigate(name, parameter);

        protected Task NavigateBack()
            => _navigationService.NavigateBack();
    }
}
