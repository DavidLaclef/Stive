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
                Nom = nom.Text,
                AdresseMail = email.Text,
                NumeroTelephone = telephone.Text,
                AdressePostale = adresse.Text,
                CodePostal = codePostal.Text,
                DateNaissance = dateNaissance.SelectedDate ?? DateTime.Now,
            });
        }
    }
}
