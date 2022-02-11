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
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<IDataService, DataService>();
		builder.Services.AddSingleton<SecondPage>();
		builder.Services.AddSingleton<SecondPageViewModel>();
		builder.Services.AddSingleton<ThirdPage>();
		builder.Services.AddSingleton<ThirdPageViewModel>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		return builder.Build();
	}
}
