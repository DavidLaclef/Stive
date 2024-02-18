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
using WPF.Views.Accueil;
using WPF.ViewModels;
using WPF.Views.Client;

namespace WPF.Views.Stock
{
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddChateau_Click(object sender, RoutedEventArgs e)
        {
            SecondCC.Content = null;
            var uc = new FormChateau();
            uc.DataContext = new ChateauxViewModel();
            SecondCC.Content = uc;
        }
    }
}
