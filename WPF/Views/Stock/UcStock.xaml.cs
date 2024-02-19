using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Stock;

/// <summary>
/// Logique d'interaction pour UcStock.xaml
/// </summary>
public partial class UcStock : UserControl
{
    public UcStock()
    {
        InitializeComponent();
    }

    private void Article_Click(object sender, RoutedEventArgs e)
    {
        StockCC.Content = null;
        var uc = new UcArticle();
        uc.DataContext = new ProduitsViewModel();
        StockCC.Content = uc;

    }

    private void Chateau_Click(object sender, RoutedEventArgs e)
    {
        StockCC.Content = null;
        var uc = new UcChateau();
        uc.DataContext = new ChateauxViewModel();
        StockCC.Content = uc;
    }

    private void Mouvement_Click(object sender, RoutedEventArgs e)
    {
        StockCC.Content = null;
        var uc = new UcMouvement();
        uc.DataContext = new MouvementStocksViewModel();
        StockCC.Content = uc;
    }

    private void Famille_Click(object sender, RoutedEventArgs e)
    {
        StockCC.Content = null;
        var uc = new UcFamille();
        uc.DataContext = new FamillesViewModel();
        StockCC.Content = uc;
    }

    private void AddChateau_Click(object sender, RoutedEventArgs e)
    {
        SecondCC.Content = null;
        var uc = new FormChateau();
        uc.DataContext = new ChateauxViewModel();
        SecondCC.Content = uc;
    }

    private void AddFamille_Click(object sender, RoutedEventArgs e)
    {
        SecondCC.Content = null;
        var uc = new FormFamille();
        uc.DataContext = new FamillesViewModel();
        SecondCC.Content = uc;
    }

    private void AddArticle_Click(object sender, RoutedEventArgs e)
    {
        SecondCC.Content = null;
        var uc = new FormProduit();
        uc.DataContext = new ChateauProduitViewModel();
        SecondCC.Content = uc;

    }

    private void AddMouvement_Click(object sender, RoutedEventArgs e)
    {
        SecondCC.Content = null;
        var uc = new FormMouvement();
        uc.DataContext = new MouvementStocksViewModel();
        SecondCC.Content = uc;
    }
}
