using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;
using WPF.Views.Stock;

namespace WPF.Views.Client;

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

    private void SupprimerClient_Click(object sender, RoutedEventArgs e)
    {
        int clientId = (int)((Button)sender).CommandParameter;

        var vm = (ClientsViewModel)this.DataContext;
        vm.SupprimerClient(clientId);

        var uc = new UcClient();
        uc.DataContext = new ClientsViewModel();
        this.Content = uc;
    }

    private void ModifierClient_Click(object sender, RoutedEventArgs e)
    {
        int ClientId = (int)((Button)sender).CommandParameter;
        var vm = (ClientsViewModel)this.DataContext;
        this.Content = null;
        var uc = new FormPutClient();
        vm.ChargerClient(ClientId);
        Content = uc;
    }

}
