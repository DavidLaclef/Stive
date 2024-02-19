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
using WPF.Views.Stock;

namespace WPF.Views.Fournisseur
{
    /// <summary>
    /// Logique d'interaction pour UcFournisseur.xaml
    /// </summary>
    public partial class UcFournisseur : UserControl
    {
        public UcFournisseur()
        {
            InitializeComponent();
        }

        private void AddFournisseur_Click(object sender, RoutedEventArgs e)
        {
            SecondCC.Content = null;
            var uc = new FormFournisseur();
            uc.DataContext = new FournisseursViewModel();
            SecondCC.Content = uc;
        }

        private void ModifierFournisseur_Click(object sender, RoutedEventArgs e)
        {
            int fournisseurId = (int)((Button)sender).CommandParameter;

            var vm = (FournisseursViewModel)this.DataContext;
            vm.SupprimerFournisseur(fournisseurId);

            var uc = new UcFournisseur();
            uc.DataContext = new FournisseursViewModel();
            this.Content = uc;

        }
    }
}
