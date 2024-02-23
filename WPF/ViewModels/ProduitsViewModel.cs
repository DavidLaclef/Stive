using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using System.Globalization;
using WPF.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPF.ViewModels;

public class ProduitsViewModel : BaseViewModel
{
    public ObservableCollection<ChateauLightDto> ListChateauLights { get; set; } = new();
    public ObservableCollection<FamilleLightDto> ListFamilleLights { get; set; } = new();

    public int NombreChateaux { get => ListChateauLights.Count(); }

    private ProduitDto _produitSelected = new();

    public ProduitDto ProduitSelected
    {
        get => _produitSelected;
        set
        {
            _produitSelected = value;
            OnPropertyChanged(nameof(ProduitSelected));
        }
    }
    public ObservableCollection<ProduitLightDto> ListProduitLights { get; set; } = new();

    public ObservableCollection<ProduitMediumDto> ListProduitMedium { get; set; } = new();

    public int NombreProduits { get => ListProduitLights.Count(); }

    public ProduitsViewModel()
    {
        LoadProduits();
        LoadChateaux();
        LoadProduitMedium();
        LoadFamilles();
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

    public void AjouterProduit(Produit newProduit)
    {
        Task.Run(async () => await HttpClientService.PostProduit(newProduit));
    }

    public void SupprimerProduit(int Id)
    {
        Task.Run(async () => await HttpClientService.DeleteProduit(Id));
    }

    public void ChargerProduit(int Id)
    {
        Task.Run(async () => await HttpClientService.GetProduitById(Id)).ContinueWith(p =>
        {

            ProduitSelected = new ProduitDto
            {
                Nom = p.Result.Nom,
                PhotoProduit = p.Result.PhotoProduit,
                Millesime = p.Result.Millesime ,
                Description = p.Result.Description,
                Quantite = p.Result.Quantite,
                SeuilReapprovisionnement = p.Result.SeuilReapprovisionnement,
                Statut = p.Result.Statut,
                PrixUnitaireVente = p.Result.PrixUnitaireVente,
                PrixCartonVente = p.Result.PrixCartonVente,
                PrixCartonCommande = p.Result.PrixCartonCommande,
                Chateau = p.Result.Chateau,
                Familles = p.Result.Familles,
                Id = p.Result.Id
            };
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void ModifierProduit(Produit produit)
    {
        Task.Run(async () => await HttpClientService.PutProduit(produit));
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

    public void LoadFamilles()
    {
        ListFamilleLights.Clear();
        ;

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


}
