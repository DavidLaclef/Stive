using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Stock;

/// <summary>
/// Logique d'interaction pour FormChateau.xaml
/// </summary>
public partial class FormChateau : UserControl
{
    public FormChateau()
    {
        InitializeComponent();
    }

    private void ajouter_Click(object sender, RoutedEventArgs e)
    {
        var vm = (ChateauxViewModel)this.DataContext;
        vm.AjouterChateau(new Models.Dao.Chateau
        {
            Nom = nom.Text,
        });
    }
}
