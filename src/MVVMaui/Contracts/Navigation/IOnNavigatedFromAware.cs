namespace MVVMaui.Contracts.Navigation
{

    public interface IOnNavigatedFromAware
    {
        Task OnNavigatedFrom(bool isForwardNavigation);
    }
}
