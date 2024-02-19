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

namespace WPF.Views.Stock
{
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
}
