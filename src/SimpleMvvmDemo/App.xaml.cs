using MVVMaui.Contracts.Navigation;

namespace SimpleMvvmDemo;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();
		MainPage = new NavigationPage();
		navigationService.Navigate("Main");
	}
}
