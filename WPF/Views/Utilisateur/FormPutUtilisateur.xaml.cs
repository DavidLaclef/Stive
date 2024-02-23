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
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Utilisateur
{
    /// <summary>
    /// Logique d'interaction pour FormPutUtilisateur.xaml
    /// </summary>
    public partial class FormPutUtilisateur : UserControl
    {
        public FormPutUtilisateur()
        {
            InitializeComponent();
        }

        private void ModifierUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            int UtilisateurId = (int)((Button)sender).CommandParameter;
            var vm = (UtilisateursViewModel)this.DataContext;
            vm.ModifierUtilisateur(new Models.Dao.Utilisateur
            {
                Id = UtilisateurId,
                Nom = nom.Text,
                Prenom = prenom.Text,
                AdresseMail = email.Text,
                MotDePasse = "test",
                EstGerant = estAdmin.IsChecked ?? false,
                CodeUtilisateur = CodePersonne.CreationCode("UTI")

            });

        }
    }
}
