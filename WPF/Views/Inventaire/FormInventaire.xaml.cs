using Models.Dao;
using Models.Enums;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Inventaire;

/// <summary>
/// Logique d'interaction pour FormInventaire.xaml
/// </summary>
public partial class FormInventaire : UserControl
{
    public FormInventaire()
    {
        InitializeComponent();
    }

    private void AddInventaire_Click(object sender, RoutedEventArgs e)
    {
        var vm = (MouvementStocksViewModel)this.DataContext;
        vm.AjouterMouvement(new Models.Dao.MouvementStock
        {
            Date = DateTime.Now,
            ProduitId = (int)NomProduit.SelectedValue,
            //Quantite = int.Parse(quantite.Text),
            NumeroMouvement = CodePersonne.CreationCode("INV"),
            Statut = Models.Enums.StatutMouvement.Traite,
        });

    }

}

