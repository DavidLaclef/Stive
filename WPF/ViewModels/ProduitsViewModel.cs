using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class ProduitsViewModel : BaseViewModel
{
    public ObservableCollection<ProduitLightDto> ListProduitLights { get; set; } = new();

    public int NombreProduits { get => ListProduitLights.Count(); }

    public ProduitsViewModel()
    {
        LoadProduits();
    }

    public void LoadProduits()
    {
        ListProduitLights.Clear();
        OnPropertyChanged(nameof(NombreProduits));

        Task.Run(async () =>
        {
            return await HttpClientService.GetProduitLights();
        }).ContinueWith(t =>
        {
            foreach (var ProduitLight in t.Result)
            {
                ListProduitLights.Add(ProduitLight);
            }
            OnPropertyChanged(nameof(NombreProduits));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void AjouterProduit(Produit newProduit)
    {
        Task.Run(async () => await HttpClientService.PostProduit(newProduit));
    }

    public void SupprimerProduit(int Id)
    {
        Task.Run(async () => await HttpClientService.DeleteProduit(Id));
    }
}
