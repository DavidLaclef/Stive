using Models.Dto;
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

namespace WPF.Views.Client
{
    /// <summary>
    /// Logique d'interaction pour UcClient.xaml
    /// </summary>
    public partial class UcClient : UserControl
    {
        public UcClient()
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

        private void ModifierClient_Click(object sender, RoutedEventArgs e)
        {
            int clientId = (int)((Button)sender).CommandParameter;

            var vm = (ClientsViewModel)this.DataContext;
            vm.SupprimerClient(clientId);

            var uc = new UcClient();
            uc.DataContext = new ClientsViewModel();
            this.Content = uc;


            // Utilisez l'ID du client comme nécessaire

        }
    }
}
