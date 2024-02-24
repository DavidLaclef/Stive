using System.Windows;
using System.Windows.Controls;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Connexion;

public partial class ucEnregistrementUtilisateur : UserControl
{
    public ucEnregistrementUtilisateur()
    {
        InitializeComponent();
    }

    private void enregistrer_Click(object sender, RoutedEventArgs e)
    {
        var vm = (UtilisateursAuthViewModel)this.DataContext;
        //vm.EnregistrerUtilisateur(email.Text, motdepasse.Text);
        vm.EnregistrerUtilisateur(email.Text, motdepasse.Password);
        email.Clear();
        motdepasse.Clear();
    }
}
