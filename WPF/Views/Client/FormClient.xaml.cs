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
            vm.AjouterClient(new Models.Dao.Client { 
                Nom = "test",//nom.Text,
                AdresseMail = "test",//email.Text,
                NumeroTelephone = "test" ,// telephone.Text,System.NullReferenceException : 'Object reference not set to an instance of an object.'

                AdressePostale = "test", //adresse.Text,
                Ville = "test",//ville.Text,    
                //CodePostal = codePostal.Text,
                CodeClient = "test",//codeClient.Text,
                EstMembreSite = true,
                MotDePasse = "test",
                DateNaissance = dateNaissance.SelectedDate ?? DateTime.Now,
                CodePostal = "test",
                Prenom = "test",

            });
        }
    }
}
