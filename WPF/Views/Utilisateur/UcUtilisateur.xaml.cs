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
using WPF.Views.Client;

namespace WPF.Views.Utilisateur
{
    /// <summary>
    /// Logique d'interaction pour UcUtilisateur.xaml
    /// </summary>
    public partial class UcUtilisateur : UserControl
    {
        public UcUtilisateur()
        {
            InitializeComponent();
        }

        private void AddUtilisateur_Click(object sender, RoutedEventArgs e)
        {
                SecondCC.Content = null;
                var uc = new FormUtilisateur();
                uc.DataContext = new UtilisateursViewModel();
                SecondCC.Content = uc;
           
        }

        private void ModifierUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            int utilisateurId = (int)((Button)sender).CommandParameter;

            var vm = (UtilisateursViewModel)this.DataContext;
            vm.SupprimerUtilisateur(utilisateurId);

            var uc = new UcUtilisateur();
            uc.DataContext = new UtilisateursViewModel();
            this.Content = uc;

        }
    }
}
