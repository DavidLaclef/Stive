using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Stock;

/// <summary>
/// Logique d'interaction pour UcChateau.xaml
/// </summary>
public partial class UcChateau : UserControl
{
    public UcChateau()
    {
        InitializeComponent();
    }

    private void SupprimerChateau_Click(object sender, RoutedEventArgs e)
    {
        int chateauId = (int)((Button)sender).CommandParameter;

        var vm = (ChateauxViewModel)this.DataContext;
        vm.SupprimerChateau(chateauId);

        var uc = new UcChateau();
        uc.DataContext = new ChateauxViewModel();
        this.Content = uc;

    }
}
