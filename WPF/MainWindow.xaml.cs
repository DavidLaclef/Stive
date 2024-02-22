using System.Windows;
using WPF.Services;
using WPF.ViewModels;
using WPF.Views.Accueil;
using WPF.Views.Client;
using WPF.Views.Fournisseur;
using WPF.Views.Stock;
using WPF.Views.Utilisateur;

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

            this.DataContext = MainViewModel.Instance; // Sur cette branche, MainViewModel est créé (je l'ai créé)

            //Task.Run(async () => await HttpClientService.Login("jeff.harbeng@stive.com", "Jeff1."));

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

    }


}