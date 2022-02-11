using SimpleMvvmDemo.Contracts.Services;

namespace SimpleMvvmDemo;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();
		MainPage = new NavigationPage();
		navigationService.NavigateToMainPage();
	}
}
