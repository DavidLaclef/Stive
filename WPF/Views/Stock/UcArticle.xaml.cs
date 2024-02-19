using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Stock;

/// <summary>
/// Logique d'interaction pour UcArticle.xaml
/// </summary>
public partial class UcArticle : UserControl
{
    public UcArticle()
    {
        InitializeComponent();
    }

    private void SupprimerProduit_Click(object sender, RoutedEventArgs e)
    {
        int produitId = (int)((Button)sender).CommandParameter;

        var vm = (ProduitsViewModel)this.DataContext;
        vm.SupprimerProduit(produitId);

        this.Content = null;
        var uc = new UcArticle();
        uc.DataContext = new UcArticle();
        this.Content = uc;

    }
}

