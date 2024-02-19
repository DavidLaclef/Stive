using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Stock;

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
