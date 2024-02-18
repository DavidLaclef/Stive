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

namespace WPF.Views.Utilisateur
{
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
                CodeUtilisateur = codeUtilisateur.Text,
                
            });

        }
    }
}
