using System.Windows.Controls;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Client;

/// <summary>
/// Logique d'interaction pour FormPutClient.xaml
/// </summary>
public partial class FormPutClient : UserControl
{
    public FormPutClient()
    {
        InitializeComponent();
    }

    private void ajouter_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        int ClientId = (int)((Button)sender).CommandParameter;
        var vm = (ClientsViewModel)this.DataContext;
        vm.ModifierClient(new Models.Dao.Client
        {
            Id = ClientId,
            Nom = nom.Text,
            Prenom = prenom.Text,
            AdresseMail = email.Text,
            NumeroTelephone = telephone.Text,
            AdressePostale = adresse.Text,
            Ville = ville.Text,
            CodeClient = CodePersonne.CreationCode("CLI"),
            EstMembreSite = true,
            MotDePasse = "test",
            DateNaissance = dateNaissance.SelectedDate ?? DateTime.Now,
            CodePostal = codePostal.Text,
            Entreprise = entreprise.Text,
            NomLivraison = nomLivraison.Text,
            PrenomLivraison = prenomLivraison.Text,
            InstructionLivraison = instructionLivraison.Text,
        });

    }
}
