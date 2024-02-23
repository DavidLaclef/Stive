using Models.Dao;
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

        int ProduitId = (int)NomProduit.SelectedValue;
        int nouvelleQuantite = int.Parse(quantite.Text);

        // Quantité du produit avant modification
        //int ancienneQuantite =

        // Difference entre les deux quantités = quantité du Mouvement
        //int differenceQuantite = nouvelleQuantite - ancienneQuantite;

        // Mettre à jour la quantité dans la base de données


        vm.AjouterMouvement(new Models.Dao.MouvementStock
        {
            Date = DateTime.Now,
            ProduitId = (int)NomProduit.SelectedValue,
            //Quantite = differenceQuantite,
            NumeroMouvement = CodePersonne.CreationCode("INV"),
            Statut = Models.Enums.StatutMouvement.Traite,
        });

    }



}

