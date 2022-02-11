namespace MVVMaui.Contracts.Navigation
{
    public interface INavigationService
    {
        Task Navigate(string name, object? parameter = null);
        Task NavigateBack();
    }
}
