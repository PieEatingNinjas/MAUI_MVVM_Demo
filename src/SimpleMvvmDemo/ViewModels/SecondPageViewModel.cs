using MVVMaui.Contracts;
using MVVMaui.Contracts.Navigation;

namespace SimpleMvvmDemo.ViewModels
{
    public class SecondPageViewModel : NavigationViewModelBase, IOnNavigatedFromAware, IOnNavigatedToAware, IOnNavigatingToAware
    {
        public Command GoBackCommand
            => new Command(async () => await NavigateBack());

        public Command NextCommand
            => new Command(async () => await Navigate("ThirdPage"));

        public SecondPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }

        public Task OnNavigatedFrom(bool isForwardNavigation)
        {
            Console.WriteLine($"On {(isForwardNavigation ? "forward" : "backward")} navigated from SecondPage");
            return Task.CompletedTask;
        }

        public Task OnNavigatingTo(object? parameter)
        {
            Console.WriteLine($"On navigating to SecondPage with parameter {parameter}");
            return Task.CompletedTask;
        }

        public Task OnNavigatedTo()
        {
            Console.WriteLine("On navigated to SecondPage");
            return Task.CompletedTask;
        }
    }
}
