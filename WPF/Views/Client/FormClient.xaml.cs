using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.ViewModels;
using WPF.Services;

namespace WPF.Views.Client
{
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
                AdressePostale =adresse.Text,
                Ville = ville.Text,
                //CodePostal = codePostal.Text,
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
}
