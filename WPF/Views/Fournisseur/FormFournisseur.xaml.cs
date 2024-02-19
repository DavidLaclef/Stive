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
using WPF.Services;

namespace WPF.Views.Fournisseur
{
    /// <summary>
    /// Logique d'interaction pour FormFournisseur.xaml
    /// </summary>
    public partial class FormFournisseur : UserControl
    {
        public FormFournisseur()
        {
            InitializeComponent();
        }

        private void AddFournisseur_Click(object sender, RoutedEventArgs e)
        {
            var vm = (FournisseursViewModel)this.DataContext;
            vm.AjouterFournisseur(new Models.Dao.Fournisseur
            {
                Nom = nom.Text,
                AdresseMail = email.Text,
                NumeroTelephone = telephone.Text,
                CodeFournisseur = CodePersonne.CreationCode("FOU")



            });
        }
    }
}
