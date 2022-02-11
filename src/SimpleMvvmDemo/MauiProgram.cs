using MVVMaui;
using SimpleMvvmDemo.Contracts.Services;
using SimpleMvvmDemo.Services;
using SimpleMvvmDemo.ViewModels;

namespace SimpleMvvmDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			//.UseMVVMauiApp<App, NavigationPage, MainPage>()
			//.UseMVVMauiApp<App, NavigationPage>("Main")
			.UseMVVMauiApp<App>("Main")
			//.UseMVVMauiApp<App, MainPage>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		//Register pages by name (bit like Prism does, which I like)
		builder.Services.AddPage<MainPage>("Main");
		builder.Services.AddPage<SecondPage>("Second");
		builder.Services.AddPage<ThirdPage>();

		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<SecondPageViewModel>();
		builder.Services.AddSingleton<ThirdPageViewModel>();

		builder.Services.AddSingleton<IDataService, DataService>();

		return builder.Build();
	}
}
