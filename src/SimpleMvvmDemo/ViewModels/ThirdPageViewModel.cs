﻿using SimpleMvvmDemo.Contracts.Services;

namespace SimpleMvvmDemo.ViewModels
{
    public class ThirdPageViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;

        public Command GoBackCommand
            => new Command(async () => await _navigationService.NavigateBack());

        public ThirdPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override Task OnNavigatedFrom(bool isForwardNavigation)
        {
            Console.WriteLine($"On {(isForwardNavigation ? "forward" : "backward")} navigated from ThirdPage");
            return base.OnNavigatedFrom(isForwardNavigation);
        }

        public override Task OnNavigatingTo(object? parameter)
        {
            Console.WriteLine($"On navigating to ThirdPage with parameter {parameter}");
            return base.OnNavigatingTo(parameter);
        }

        public override Task OnNavigatedTo()
        {
            Console.WriteLine("On navigated to ThirdPage");
            return base.OnNavigatedTo();
        }
    }
}
