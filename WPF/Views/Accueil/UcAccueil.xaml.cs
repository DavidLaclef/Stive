using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;
using WPF.Views.Client;

namespace WPF.Views.Accueil;

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

