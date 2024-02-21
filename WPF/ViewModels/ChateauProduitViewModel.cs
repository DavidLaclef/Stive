using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class ChateauProduitViewModel : BaseViewModel
{
    public ObservableCollection<ChateauLightDto> ListChateauLights { get; set; } = new();

    public int NombreChateaux { get => ListChateauLights.Count(); }
    public ObservableCollection<ProduitLightDto> ListProduitLights { get; set; } = new();

    public int NombreProduits { get => ListProduitLights.Count(); }

    public ChateauProduitViewModel()
    {
        LoadProduits();
        LoadChateaux();
    }

    public void LoadChateaux()
    {
        ListChateauLights.Clear();
        OnPropertyChanged(nameof(NombreChateaux));

        Task.Run(async () =>
        {
            return await HttpClientService.GetChateauLights();
        }).ContinueWith(t =>
        {
            foreach (var ChateauLight in t.Result)
            {
                ListChateauLights.Add(ChateauLight);
            }
            OnPropertyChanged(nameof(NombreChateaux));
        }, TaskScheduler.FromCurrentSynchronizationContext());
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


}
