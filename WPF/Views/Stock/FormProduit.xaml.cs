using Models.Dao;
using Models.Enums;
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
    /// Logique d'interaction pour FormProduit.xaml
    /// </summary>
    public partial class FormProduit : UserControl
    {
        public FormProduit()
        {
            InitializeComponent();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            var vm = (ChateauProduitViewModel)this.DataContext;
            vm.AjouterProduit(new Models.Dao.Produit
            {
                Nom = Nom.Text,
                PhotoProduit = PhotoProduit.Text,
                Millesime = millesime.SelectedDate ?? DateTime.Now ,
                Description = Description.Text,
                Quantite = int.Parse(Quantite.Text),
                SeuilReapprovisionnement = int.Parse(reapprovisionnement.Text),
                Statut = StatutProduit.Ok,
                PrixUnitaireVente = decimal.Parse(prixUnitaire.Text),
                PrixCartonVente = decimal.Parse(PrixCartonVente.Text),
                PrixCartonCommande = decimal.Parse(prixcartoncommande.Text),
                ChateauId = 3,
              

            });

        }
    }
}
