
using System.Windows;
using WPF.Views.Accueil;
using WPF.Views.Client;
using WPF.Views.Fournisseur;
using WPF.Views.Stock;
using WPF.Views.Utilisateur;
using WPF.ViewModels;
namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //initier les variables run ce code lors du démarrage de la page


        }

        private void BtnAccueil_Click(object sender, RoutedEventArgs e)
        {
            mainCC.Content = null;
            var uc = new UcAccueil();
            uc.DataContext = uc;
            mainCC.Content = uc;

        }

        private void BtnStocks_Click(object sender, RoutedEventArgs e)
        {
            mainCC.Content = null;
            var uc = new UcStock();
            uc.DataContext = uc;
            mainCC.Content = uc;

        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            mainCC.Content = null;
            var uc = new UcClient();
            uc.DataContext = new ClientsViewModel();
            mainCC.Content = uc;

        }

        private void BtnFournisseur_Click(object sender, RoutedEventArgs e)
        {
            mainCC.Content = null;
            var uc = new UcFournisseur();
            uc.DataContext = new FournisseursViewModel();
            mainCC.Content = uc;
        }

        private void BtnUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            mainCC.Content = null;
            var uc = new UcUtilisateur();
            uc.DataContext = new UtilisateursViewModel();
            mainCC.Content = uc;
        }

        private void BtnProduit_Click(object sender, RoutedEventArgs e)
        {
            mainCC.Content = null;
            var uc = new FormClient();
            uc.DataContext = new ClientsViewModel();
            mainCC.Content = uc;
        }
    }


}