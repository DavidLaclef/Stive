using System.Windows;
using WPF.ViewModels;
using WPF.Views.Accueil;
using WPF.Views.Client;
using WPF.Views.Connexion;
using WPF.Views.Fournisseur;
using WPF.Views.Stock;
using WPF.Views.Utilisateur;

namespace WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Gestion de l'évènement dans le code directement
        BtnConnexion.Click += BtnConnexion_Click;
        BtnConnexion_Click(BtnConnexion, null);

        //this.DataContext = MainViewModel.Instance; // Sur cette branche, MainViewModel est créé (je l'ai créé)

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

    private void BtnConnexion_Click(object sender, RoutedEventArgs e)
    {
        mainCC.Content = null;
        var uc = new ucConnexionUtilisateur();
        uc.ConnexionChange += Uc_ConnexionChange;
        uc.DataContext = new UtilisateursAuthViewModel();
        mainCC.Content = uc;
    }

    private void Uc_ConnexionChange(object? sender, EventArgs e)
    {
        BtnAccueil.Visibility = Visibility.Visible;
        BtnStocks.Visibility = Visibility.Visible;
        BtnClient.Visibility = Visibility.Visible;
        BtnFournisseur.Visibility = Visibility.Visible;
        BtnUtilisateur.Visibility = Visibility.Visible;

        // Boutons relatifs au compte utilisateurs
        BtnConnexion.Visibility = Visibility.Collapsed;
        BtnNouvelleUtilisateur.Visibility = Visibility.Visible;
        // Redirection vers L'acceuil
        BtnAccueil_Click(BtnAccueil, null);
    }

    private void BtnNouvelleUtilisateur_Click(object sender, RoutedEventArgs e)
    {
        mainCC.Content = null;
        var uc = new ucEnregistrementUtilisateur();
        uc.DataContext = new UtilisateursAuthViewModel();
        mainCC.Content = uc;
    }
}