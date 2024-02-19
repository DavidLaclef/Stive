using System.Windows;
using System.Windows.Controls;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Utilisateur;

/// <summary>
/// Logique d'interaction pour FormUtilisateur.xaml
/// </summary>
public partial class FormUtilisateur : UserControl
{
    public FormUtilisateur()
    {
        InitializeComponent();
    }

    private void ajouter_Click(object sender, RoutedEventArgs e)
    {
        var vm = (UtilisateursViewModel)this.DataContext;
        vm.AjouterUtilisateur(new Models.Dao.Utilisateur
        {
            Nom = nom.Text,
            Prenom = prenom.Text,
            AdresseMail = email.Text,
            MotDePasse = "test",
            EstGerant = estAdmin.IsChecked ?? false,
            CodeUtilisateur = CodePersonne.CreationCode("UTI")

        });

    }
}
