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
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Views.Stock
{
    /// <summary>
    /// Logique d'interaction pour FormMouvement.xaml
    /// </summary>
    public partial class FormMouvement : UserControl
    {
        public FormMouvement()
        {
            InitializeComponent();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            var vm = (MouvementStocksViewModel)this.DataContext;
            vm.AjouterMouvementStock(new Models.Dao.MouvementStock
            {
                Date = DateMouvement.SelectedDate.Value,
                Quantite = int.Parse(Quantite.Text),
                Remise = 0,
                ProduitId = (int)Produit.SelectedValue,
                Statut = StatutMouvement.EnAttente,
                NumeroMouvement  = CodePersonne.CreationCode("COR")
            });

            vm.MettreAjourProduit((int)Produit.SelectedValue);

        }
    }
}
