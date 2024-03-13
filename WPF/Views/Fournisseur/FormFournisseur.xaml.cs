using System.Windows;
using System.Windows.Controls;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Fournisseur;

/// <summary>
/// Logique d'interaction pour FormFournisseur.xaml
/// </summary>
public partial class FormFournisseur : UserControl
{
    public FormFournisseur()
    {
        InitializeComponent();
    }

    private void AddFournisseur_Click(object sender, RoutedEventArgs e)
    {
        var vm = (FournisseursViewModel)this.DataContext;
        vm.AjouterFournisseur(new Models.Dao.Fournisseur
        {
            Nom = nom.Text,
            AdresseMail = email.Text,
            NumeroTelephone = telephone.Text,
            CodeFournisseur = CodePersonne.CreationCode("FOU")
        });
    }
}


