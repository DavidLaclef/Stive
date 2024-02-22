using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Stock;

/// <summary>
/// Logique d'interaction pour UcFamille.xaml
/// </summary>
public partial class UcFamille : UserControl
{
    public UcFamille()
    {
        InitializeComponent();
    }

    private void SupprimerFamille_Click(object sender, RoutedEventArgs e)
    {
        int familleId = (int)((Button)sender).CommandParameter;

        var vm = (FamillesViewModel)this.DataContext;
        vm.SupprimerFamille(familleId);

        var uc = new UcFamille();
        uc.DataContext = new FamillesViewModel();
        this.Content = uc;

    }

    private void ModifierFamille_Click(object sender, RoutedEventArgs e)
    {
        int FamilleId = (int)((Button)sender).CommandParameter;
        var vm = (FamillesViewModel)this.DataContext;
        this.Content = null;
        var uc = new FormPutFamille();
        vm.ChargerFamille(FamilleId);
        Content = uc;

    }
}
