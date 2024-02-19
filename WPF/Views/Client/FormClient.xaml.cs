using System.Windows;
using System.Windows.Controls;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Client;

/// <summary>
/// Logique d'interaction pour FormClient.xaml
/// </summary>
public partial class FormClient : UserControl
{
    public FormClient()
    {
        InitializeComponent();
    }

    private void ajouter_Click(object sender, RoutedEventArgs e)
    {
        var vm = (ClientsViewModel)this.DataContext;
        vm.AjouterClient(new Models.Dao.Client
        {

            Nom = nom.Text,
            AdresseMail = email.Text,
            NumeroTelephone = telephone.Text,
            AdressePostale = adresse.Text,
            Ville = ville.Text,
            CodeClient = CodePersonne.CreationCode("CLI"),

            EstMembreSite = true,
            MotDePasse = "test",
            DateNaissance = dateNaissance.SelectedDate ?? DateTime.Now,
            CodePostal = codePostal.Text,
            Prenom = prenom.Text,
            Entreprise = entreprise.Text,
            NomLivraison = nomLivraison.Text,
            PrenomLivraison = prenomLivraison.Text,
            InstructionLivraison = instructionLivraison.Text,
        });
    }
}
