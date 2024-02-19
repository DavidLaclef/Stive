using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Fournisseur;

/// <summary>
/// Logique d'interaction pour UcFournisseur.xaml
/// </summary>
public partial class UcFournisseur : UserControl
{
    public UcFournisseur()
    {
        InitializeComponent();
    }

    private void AddFournisseur_Click(object sender, RoutedEventArgs e)
    {
        SecondCC.Content = null;
        var uc = new FormFournisseur();
        uc.DataContext = new FournisseursViewModel();
        SecondCC.Content = uc;
    }

    private void ModifierFournisseur_Click(object sender, RoutedEventArgs e)
    {
        int fournisseurId = (int)((Button)sender).CommandParameter;

        var vm = (FournisseursViewModel)this.DataContext;
        vm.SupprimerFournisseur(fournisseurId);

        var uc = new UcFournisseur();
        uc.DataContext = new FournisseursViewModel();
        this.Content = uc;

    }
}
