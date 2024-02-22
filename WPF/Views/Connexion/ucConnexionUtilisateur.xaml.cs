using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Connexion;

public partial class ucConnexionUtilisateur : UserControl
{
    public ucConnexionUtilisateur()
    {
        InitializeComponent();
    }

    private void connecter_Click(object sender, RoutedEventArgs e)
    {
        var vm = (UtilisateursAuthViewModel)this.DataContext;
        vm.AuthentifierUtilisateur(email.Text, motdepasse.Text);
    }
}
