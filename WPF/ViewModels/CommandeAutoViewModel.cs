using Models.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Services;

namespace WPF.ViewModels
{
    internal class CommandeAutoViewModel : BaseViewModel
    {
        public ObservableCollection<ProduitLightDto> ListProduitLights { get; set; } = new();

        public CommandeAutoViewModel()
        {
            GetProduitLowStock();
        }

        public void GetProduitLowStock()
        {
            ListProduitLights.Clear();

            Task.Run(async () =>
            {
                return await HttpClientService.GetProduitLights();
            }).ContinueWith(t =>
            {
                foreach (var ProduitLight in t.Result)
                {
                    if (ProduitLight.Quantite < ProduitLight.SeuilReapprovisionnement)
                    {
                        ListProduitLights.Add(ProduitLight);
                    }
                    
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
