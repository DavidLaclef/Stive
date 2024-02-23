using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class MouvementStocksViewModel : BaseViewModel
{
    public ObservableCollection<MouvementStockLightDto> ListMouvementStockLights { get; set; } = new();

    public ObservableCollection<MouvementStockMediumDto> ListMouvementStockMedium{ get; set; } = new();

    public ObservableCollection<ProduitMediumDto> ListProduitMedium { get; set; } = new();
    
    public ObservableCollection<ChateauLightDto> ListChateauLights { get; set; } = new();

    public ObservableCollection<FamilleLightDto> ListFamilleLights { get; set; } = new();

    public int NombreMouvementStocks { get => ListMouvementStockLights.Count(); }

    public MouvementStocksViewModel()
    {
        LoadMouvementStocks();
        LoadMouvementStockMedium();
        LoadProduits();
        LoadProduitMedium();
        LoadChateaux();
        LoadFamilles();
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

    public void LoadMouvementStockMedium()
    {
        ListMouvementStockMedium.Clear();

        Task.Run(async () =>
        {
            return await HttpClientService.GetMouvementStockMedium();
        }).ContinueWith(t =>
        {
            foreach (var MouvementStockMedium in t.Result)
            {
                ListMouvementStockMedium.Add(MouvementStockMedium);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void AjouterMouvementStock(MouvementStock newMouvementStock)
    {
        Task.Run(async () => await HttpClientService.PostMouvementStock(newMouvementStock));
    }



    public void MettreAjourProduit(int Id)
    {
/*
        var Produit = Task.Run(async () => { return await HttpClientService.GetProduit(Id); }).ContinueWith(t =>
        {

            var Produit = t.Result;


        }
              );

        var roduit = Task.Run(async () => await HttpClientService.PutProduit());*/
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

    public void LoadProduitMedium()
    {
        ListProduitMedium.Clear();

        Task.Run(async () =>
        {
            return await HttpClientService.GetProduitMedium();
        }).ContinueWith(t =>
        {
            foreach (var ProduitMedium in t.Result)
            {
                ListProduitMedium.Add(ProduitMedium);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void LoadChateaux()
    {
        ListChateauLights.Clear();

        Task.Run(async () =>
        {
            return await HttpClientService.GetChateauLights();
        }).ContinueWith(t =>
        {
            foreach (var ChateauLight in t.Result)
            {
                ListChateauLights.Add(ChateauLight);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void LoadFamilles()
    {
        ListFamilleLights.Clear();

        Task.Run(async () =>
        {
            return await HttpClientService.GetFamilleLights();
        }).ContinueWith(t =>
        {
            foreach (var FamilleLight in t.Result)
            {
                ListFamilleLights.Add(FamilleLight);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }



    public void AjouterMouvement(MouvementStock newMouvement)
    {
        Task.Run(async () => await HttpClientService.PostMouvementStock(newMouvement));
    }

    

}
