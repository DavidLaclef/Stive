using Models.Dao;
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

namespace WPF.Views.Stock
{
    /// <summary>
    /// Logique d'interaction pour UcArticle.xaml
    /// </summary>
    public partial class UcArticle : UserControl
    {
        public UcArticle()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //// Récupérer l'article sélectionné dans la ListBox
            //Produit selectedProduit = (sender as ListBox).SelectedItem as Produit;

            //if (selectedProduit != null)
            //{
            //    // Récupérer l'ID de l'article sélectionné
            //    int produitId = selectedProduit.Id;

            //    // Passer l'ID à votre popup pour le bindage
            //    myPopup.DataContext = produitId;

            //    // Afficher la popup
            //    myPopup.IsOpen = true;
            //}
            myPopup.IsOpen = true;
        }
    }
}

