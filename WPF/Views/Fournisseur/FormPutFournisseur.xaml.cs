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

namespace WPF.Views.Fournisseur
{
    /// <summary>
    /// Logique d'interaction pour FormPutFournisseur.xaml
    /// </summary>
    public partial class FormPutFournisseur : UserControl
    {
        public FormPutFournisseur()
        {
            InitializeComponent();
        }

        private void ModifierFournisseur_Click(object sender, RoutedEventArgs e)
        {
            int fournisseurId = (int)((Button)sender).CommandParameter;
            var vm = (FournisseursViewModel)this.DataContext;
            vm.ModifierFournisseur(new Models.Dao.Fournisseur
            {
                Id = fournisseurId,
                Nom = nom.Text,
                AdresseMail = email.Text,
                NumeroTelephone = telephone.Text,
                CodeFournisseur = CodePersonne.CreationCode("FOU")
            });

        }
    }
}
