using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Utilisateur;

/// <summary>
/// Logique d'interaction pour UcUtilisateur.xaml
/// </summary>
public partial class UcUtilisateur : UserControl
{
    public UcUtilisateur()
    {
        InitializeComponent();
    }

    private void AddUtilisateur_Click(object sender, RoutedEventArgs e)
    {
        SecondCC.Content = null;
        var uc = new FormUtilisateur();
        uc.DataContext = new UtilisateursViewModel();
        SecondCC.Content = uc;
    }

    private void SupprimerUtilisateur_Click(object sender, RoutedEventArgs e)
    {
        int utilisateurId = (int)((Button)sender).CommandParameter;

        var vm = (UtilisateursViewModel)this.DataContext;
        vm.SupprimerUtilisateur(utilisateurId);

        var uc = new UcUtilisateur();
        uc.DataContext = new UtilisateursViewModel();
        this.Content = uc;

    }

    private void ModifierUtilisateur_Click(object sender, RoutedEventArgs e)
    {
        int UtilisateurId = (int)((Button)sender).CommandParameter;
        var vm = (UtilisateursViewModel)this.DataContext;
        this.Content = null;
        var uc = new FormPutUtilisateur();
        vm.ChargerUtilisateur(UtilisateurId);
        Content = uc;

    }

}
