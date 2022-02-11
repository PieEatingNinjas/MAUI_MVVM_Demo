using MVVMaui.Contracts;
using MVVMaui.Contracts.Navigation;

namespace SimpleMvvmDemo.ViewModels
{
    public class ThirdPageViewModel : IOnNavigatedFromAware, IOnNavigatedToAware, IOnNavigatingToAware
    {
        readonly INavigationService _navigationService;

        public Command GoBackCommand
            => new Command(async () => await _navigationService.NavigateBack());

        public ThirdPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

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
