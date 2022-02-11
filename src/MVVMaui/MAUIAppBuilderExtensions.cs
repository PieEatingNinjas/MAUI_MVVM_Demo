using MVVMaui.Contracts.Navigation;
using MVVMaui.Navigation;

namespace MVVMaui;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseMVVMauiApp<TApp, TMainPage, TStartPage>(this MauiAppBuilder @this) 
        where TApp : Application
        where TMainPage : Page, new()
        where TStartPage : Page
    {
        @this.Services.AddSingleton<TApp>();
        @this.Services.AddSingleton<INavigationService, NavigationService>();

        @this.UseMauiApp(serviceProvider =>
        {
            var app = serviceProvider.GetRequiredService<TApp>();
            app.MainPage = new TMainPage();
            var navigation = serviceProvider.GetRequiredService<INavigationService>();
            navigation.Navigate<TStartPage>();
            return app;
        });

        return @this;
    }

    public static MauiAppBuilder UseMVVMauiApp<TApp, TMainPage>(this MauiAppBuilder @this, string startPage)
        where TApp : Application
        where TMainPage : Page, new()
    {
        @this.Services.AddSingleton<TApp>();
        @this.Services.AddSingleton<INavigationService, NavigationService>();

        @this.UseMauiApp(serviceProvider =>
        {
            var app = serviceProvider.GetRequiredService<TApp>();
            app.MainPage = new TMainPage();
            var navigation = serviceProvider.GetRequiredService<INavigationService>();
            navigation.Navigate(startPage);
            return app;
        });

        return @this;
    }

    public static MauiAppBuilder UseMVVMauiApp<TApp, TStartPage>(this MauiAppBuilder @this)
        where TApp : Application
        where TStartPage : Page
    {
        @this.Services.AddSingleton<TApp>();
        @this.Services.AddSingleton<INavigationService, NavigationService>();

        @this.UseMauiApp(serviceProvider =>
        {
            var app = serviceProvider.GetRequiredService<TApp>();
            app.MainPage = new NavigationPage();
            var navigation = serviceProvider.GetRequiredService<INavigationService>();
            navigation.Navigate<TStartPage>();
            return app;
        });

        return @this;
    }

    public static MauiAppBuilder UseMVVMauiApp<TApp>(this MauiAppBuilder @this, string startPage)
        where TApp : Application
    {
        @this.Services.AddSingleton<TApp>();
        @this.Services.AddSingleton<INavigationService, NavigationService>();

        @this.UseMauiApp(serviceProvider =>
        {
            var app = serviceProvider.GetRequiredService<TApp>();
            app.MainPage = new NavigationPage();
            var navigation = serviceProvider.GetRequiredService<INavigationService>();
            navigation.Navigate(startPage);
            return app;
        });

        return @this;
    }
}
