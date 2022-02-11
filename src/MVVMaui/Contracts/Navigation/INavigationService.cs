namespace MVVMaui.Contracts.Navigation
{
    public interface INavigationService
    {
        Task Navigate(string name, object? parameter = null);
        Task NavigateBack();
        Task Navigate<T>(object? parameter = null) where T : Page;
    }
}
