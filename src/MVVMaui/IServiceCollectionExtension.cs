using MVVMaui.Contracts.Navigation;
using MVVMaui.Navigation;

namespace MVVMaui;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddPage<T>(this IServiceCollection @this, string? name = null) where T : Page
    {
        NavigationService.Registrations.Add(name ?? typeof(T).Name, typeof(T));
        @this.AddSingleton<T>();
        return @this;
    }
}