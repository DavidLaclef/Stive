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
    /// Logique d'interaction pour UcFamille.xaml
    /// </summary>
    public partial class UcFamille : UserControl
    {
        public UcFamille()
        {
            InitializeComponent();
        }



        private void SupprimerFamille_Click(object sender, RoutedEventArgs e)
        {
            int familleId = (int)((Button)sender).CommandParameter;

            var vm = (FamillesViewModel)this.DataContext;
            vm.SupprimerFamille(familleId);

            var uc = new UcFamille();
            uc.DataContext = new FamillesViewModel();
            this.Content = uc;

        }
    }
}
