using MVVMaui.Contracts;
using MVVMaui.Contracts.Navigation;
using SimpleMvvmDemo.Contracts.Services;

namespace SimpleMvvmDemo.ViewModels
{
    public class MainPageViewModel : NavigationViewModelBase,  IOnNavigatedFromAware, IOnNavigatedToAware, IOnNavigatingToAware
    {
        readonly IDataService _dataService;

        public Command NavigateCommand
            => new Command(async () => await Navigate("Second", "some id"));

        public MainPageViewModel(IDataService dataService, INavigationService navigationService) 
            : base(navigationService)
        {
            _dataService = dataService;
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
