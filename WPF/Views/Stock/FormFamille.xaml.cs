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
    /// Logique d'interaction pour FormFamille.xaml
    /// </summary>
    public partial class FormFamille : UserControl
    {
        public FormFamille()
        {
            InitializeComponent();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            var vm = (FamillesViewModel)this.DataContext;
            vm.AjouterFamille(new Models.Dao.Famille
            {
                Nom = nom.Text,
            });
        }
    }
}
