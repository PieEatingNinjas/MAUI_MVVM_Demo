using MVVMaui.Contracts;
using MVVMaui.Contracts.Navigation;

namespace SimpleMvvmDemo.ViewModels
{
    public class ThirdPageViewModel : NavigationViewModelBase, IOnNavigatedFromAware, IOnNavigatedToAware, IOnNavigatingToAware
    {
        public Command GoBackCommand
            => new Command(async () => await NavigateBack());

        public ThirdPageViewModel(INavigationService navigationService) : base(navigationService)
        { }

        public Task OnNavigatedFrom(bool isForwardNavigation)
        {
            Console.WriteLine($"On {(isForwardNavigation ? "forward" : "backward")} navigated from ThirdPage");
            return Task.CompletedTask;
        }

        public Task OnNavigatingTo(object? parameter)
        {
            Console.WriteLine($"On navigating to ThirdPage with parameter {parameter}");
            return Task.CompletedTask;
        }

        public Task OnNavigatedTo()
        {
            Console.WriteLine("On navigated to ThirdPage");
            return Task.CompletedTask;
        }
    }
}
