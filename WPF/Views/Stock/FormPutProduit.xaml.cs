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
    /// Logique d'interaction pour FormPutProduit.xaml
    /// </summary>
    public partial class FormPutProduit : UserControl
    {
        public FormPutProduit()
        {
            InitializeComponent();

           

        }

        private void ModifierProduit_Click(object sender, RoutedEventArgs e)
        {
            int produitId = (int)((Button)sender).CommandParameter;
            var vm = (ProduitsViewModel)this.DataContext;
            vm.ModifierProduit(new Models.Dao.Produit
            {
                Id = produitId,
                Nom = Nom.Text,
                PhotoProduit = PhotoProduit.Text,
                Millesime = DateTime.ParseExact( millesime.Text, "yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Description = Description.Text,
                Quantite = int.Parse(Quantite.Text),
                SeuilReapprovisionnement = int.Parse(reapprovisionnement.Text),
                Statut = StatutProduit.Ok,
/*                PrixUnitaireVente= 30,
                PrixCartonVente= 30,
                PrixCartonCommande= 30,
                ChateauId = (int)ChateauId.SelectedValue*/
                PrixUnitaireVente = decimal.Parse(prixUnitaire.Text.Replace(".",",")),
                PrixCartonVente = decimal.Parse(PrixCartonVente.Text.Replace(".", ",")),
                PrixCartonCommande = decimal.Parse(prixcartoncommande.Text.Replace(".", ",")),
                ChateauId = (int)ChateauId.SelectedValue,
                //Famille = new Famille(int)FamilleId.SelectedValue
            });

        }
    }
}
