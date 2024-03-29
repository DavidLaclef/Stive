﻿using System;
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
    /// Logique d'interaction pour FormPutChateau.xaml
    /// </summary>
    public partial class FormPutChateau : UserControl
    {
        public FormPutChateau()
        {
            InitializeComponent();
        }

        private void ModifierChateau_Click(object sender, RoutedEventArgs e)
        {
            int chateauId = (int)((Button)sender).CommandParameter;
            var vm = (ChateauxViewModel)this.DataContext;
            vm.ModifierChateau(new Models.Dao.Chateau
            {
                Id = chateauId,
                Nom = nom.Text,
            });

        }
    }
}
