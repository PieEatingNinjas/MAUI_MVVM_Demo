using MVVMaui.Contracts;
using MVVMaui.Contracts.Navigation;
using SimpleMvvmDemo.Contracts.Services;

namespace SimpleMvvmDemo.ViewModels
{
    public class MainPageViewModel :  IOnNavigatedFromAware, IOnNavigatedToAware, IOnNavigatingToAware
    {
    {
        readonly IDataService _dataService;
        readonly INavigationService _navigationService;

        public Command NavigateCommand
            => new Command(async () => await _navigationService.Navigate("Second", "some id"));

        public MainPageViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
        }

        public Task OnNavigatedFrom(bool isForwardNavigation)
        {
            Console.WriteLine($"On {(isForwardNavigation ? "forward" : "backward")} navigated from MainPage");
            return Task.CompletedTask;
        }

        public Task OnNavigatingTo(object? parameter)
        {
            Console.WriteLine($"On navigating to MainPage with parameter {parameter}");
            return Task.CompletedTask;
        }

        public Task OnNavigatedTo()
        {
            Console.WriteLine("On navigated to MainPage");
            return Task.CompletedTask;
        }
    }
}
