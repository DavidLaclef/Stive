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
    /// Logique d'interaction pour FormPutFamille.xaml
    /// </summary>
    public partial class FormPutFamille : UserControl
    {
        public FormPutFamille()
        {
            InitializeComponent();
        }

        private void ModifierFamille_Click(object sender, RoutedEventArgs e)
        {
            int familleId = (int)((Button)sender).CommandParameter;
            var vm = (FamillesViewModel)this.DataContext;
            vm.ModifierFamille(new Models.Dao.Famille
            {
                Id = familleId,
                Nom = nom.Text,
            });

        }
    }
}
