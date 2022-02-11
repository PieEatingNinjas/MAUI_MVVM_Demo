namespace MVVMaui.Contracts
{
    //public abstract class ViewModelBase : INotifyPropertyChanged
    //{
    //    public virtual Task OnNavigatingTo(object? parameter)
    //        => Task.CompletedTask;

    //    public virtual Task OnNavigatedFrom(bool isForwardNavigation)
    //        => Task.CompletedTask;

    //    public virtual Task OnNavigatedTo()
    //        => Task.CompletedTask;

    //    public virtual void RaisePropertyChanged([CallerMemberName] string? property = null)
    //        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    //    public event PropertyChangedEventHandler? PropertyChanged;
    //}

    public interface IOnNavigatingToAware
    {
        Task OnNavigatingTo(object? parameter);
    }

    public interface IOnNavigatedToAware
    {
        Task OnNavigatedTo();
    }

    public interface IOnNavigatedFromAware
    {
        Task OnNavigatedFrom(bool isForwardNavigation);
    }
}
