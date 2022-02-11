namespace MVVMaui.Contracts.Navigation
{
    public interface IOnNavigatingToAware
    {
        Task OnNavigatingTo(object? parameter);
    }
}
