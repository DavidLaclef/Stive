namespace WPF.ViewModels;

public class MainViewModel : BaseViewModel
{
    #region Singleton

    private static MainViewModel instance = new MainViewModel();
    public static MainViewModel Instance => instance;

    private MainViewModel() { }

    #endregion
}
