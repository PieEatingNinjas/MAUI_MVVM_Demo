using MVVMaui.Contracts.Navigation;
using MVVMaui.Navigation;

namespace MVVMaui
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder UseMVVMAUI(this MauiAppBuilder @this)
        {
            @this.Services.AddSingleton<INavigationService, NavigationService>();
            return @this;
        }
    }
}
