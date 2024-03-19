using System.Windows;
using WPF.ViewModels;
using WPF.Views.Accueil;
using WPF.Views.Client;
using WPF.Views.Connexion;
using WPF.Views.Fournisseur;
using WPF.Views.Inventaire;
using WPF.Views.Stock;
using WPF.Views.Utilisateur;

namespace WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Connexion à l'application
        BtnConnexion.Click += BtnConnexion_Click;
        BtnConnexion_Click(BtnConnexion, null!);
    }

    private void BtnInventaire_Click(object sender, RoutedEventArgs e)
    {
        mainCC.Content = null;
        var uc = new UcInventaire();
        uc.DataContext = new MouvementStocksViewModel();
        mainCC.Content = uc;
    }

    private void BtnAccueil_Click(object sender, RoutedEventArgs? e)
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
        BtnFournisseur.Visibility = Visibility.Visible;
        BtnUtilisateur.Visibility = Visibility.Visible;
        
        BtnConnexion.Visibility = Visibility.Collapsed;
        BtnNouvelUtilisateur.Visibility = Visibility.Visible; // Il est possible de créer un utilisateur seuelemnt si l'on est connecté (seul le gérant a un compte et peut se connecter)

        // Redirection vers L'acceuil
        BtnAccueil_Click(BtnAccueil, null);
    }

    private void BtnNouvelUtilisateur_Click(object sender, RoutedEventArgs e)
    {
        mainCC.Content = null;
        var uc = new ucEnregistrementUtilisateur();
        uc.DataContext = new UtilisateursAuthViewModel();
        mainCC.Content = uc;
    }
}