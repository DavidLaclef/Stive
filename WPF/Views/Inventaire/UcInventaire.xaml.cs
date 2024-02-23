using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Inventaire
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class UcInventaire : UserControl
    {
        public UcInventaire()
        {
            InitializeComponent();
        }

        private void AddInventaire_Click(object sender, RoutedEventArgs e)
        {
            SecondCC.Content = null;
            var uc = new FormInventaire();
            uc.DataContext = new MouvementStocksViewModel();
            SecondCC.Content = uc;
        }
    }
}
