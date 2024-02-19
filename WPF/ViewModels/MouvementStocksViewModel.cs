using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class MouvementStocksViewModel : BaseViewModel
{
    public ObservableCollection<MouvementStockLightDto> ListMouvementStockLights { get; set; } = new();

    public int NombreMouvementStocks { get => ListMouvementStockLights.Count(); }

    public MouvementStocksViewModel()
    {
        LoadMouvementStocks();
        LoadProduits();
    }

    public void LoadMouvementStocks()
    {
        ListMouvementStockLights.Clear();
        OnPropertyChanged(nameof(NombreMouvementStocks));

        Task.Run(async () =>
        {
            return await HttpClientService.GetMouvementStockLights();
        }).ContinueWith(t =>
        {
            foreach (var MouvementStockLight in t.Result)
            {
                ListMouvementStockLights.Add(MouvementStockLight);
            }
            OnPropertyChanged(nameof(NombreMouvementStocks));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void AjouterMouvementStock(MouvementStock newMouvementStock)
    {
        Task.Run(async () => await HttpClientService.PostMouvementStock(newMouvementStock));
    }

    public void MettreAjourProduit(int Id)
    {
        Task.Run(async () => await HttpClientService.PutProduit(Task.Run(async () => await HttpClientService.GetProduit(Id)).Result));
    }

    public ObservableCollection<ProduitLightDto> ListProduitLights { get; set; } = new();

    public int NombreProduits { get => ListProduitLights.Count(); }


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


}
