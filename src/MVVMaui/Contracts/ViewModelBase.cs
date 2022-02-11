using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMaui.Contracts
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public virtual void RaisePropertyChanged([CallerMemberName] string? property = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
