using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    #region PropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    // Notification des modifications de propriétés 
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    #endregion
}

