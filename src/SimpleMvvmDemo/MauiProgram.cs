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
			.UseMVVMAUI() //Register our navigation service
			.UseMauiApp<App>()
        #region brainfarts
            //.WithMainPage("Main") //would it be interesting to do something like this
            //.WithMainPage<MainPage>() //or this?
            //.UseMauiApp<App>("Main") //or this?
        #endregion
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
