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
using WPF.Views.Client;

namespace WPF.Views.Accueil
{
    /// <summary>
    /// Logique d'interaction pour UcAccueil.xaml
    /// </summary>
    public partial class UcAccueil : UserControl
    {
        public UcAccueil()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            SecondCC.Content = null;
            var uc = new FormClient();
            uc.DataContext = new ClientsViewModel();
            SecondCC.Content = uc;
        }

        private void AddVente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

