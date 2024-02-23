using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class FournisseursViewModel : BaseViewModel
{
    public ObservableCollection<FournisseurLightDto> ListFournisseurLights { get; set; } = new();

    private Fournisseur _fournisseurSelected = new();

    public Fournisseur FournisseurSelected
    {
        get => _fournisseurSelected;
        set
        {
            _fournisseurSelected = value;
            OnPropertyChanged(nameof(FournisseurSelected));
        }
    }  

    public int NombreFournisseurs { get => ListFournisseurLights.Count(); }



    public FournisseursViewModel()
    {
        LoadFournisseurs();
    }

    public void LoadFournisseurs()
    {
        ListFournisseurLights.Clear();
        OnPropertyChanged(nameof(NombreFournisseurs));

        Task.Run(async () =>
        {
            return await HttpClientService.GetFournisseurLights();
        }).ContinueWith(t =>
        {
            foreach (var FournisseurLight in t.Result)
            {
                ListFournisseurLights.Add(FournisseurLight);
            }
            OnPropertyChanged(nameof(NombreFournisseurs));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void AjouterFournisseur(Fournisseur newFournisseur)
    {
        Task.Run(async () => await HttpClientService.PostFournisseur(newFournisseur));
    }

    public void SupprimerFournisseur(int Id)
    {
        Task.Run(async () => await HttpClientService.DeleteFournisseur(Id));
    }

    public void ChargerFournisseur(int Id)
    {
        Task.Run(async () => await HttpClientService.GetFournisseurById(Id)).ContinueWith(t =>
        {
            FournisseurSelected = new Fournisseur {
                Id = t.Result.Id,
                Nom = t.Result.Nom,
                AdresseMail = t.Result.AdresseMail,
                NumeroTelephone = t.Result.NumeroTelephone,
                CodeFournisseur = t.Result.NumeroTelephone

            } ;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void ModifierFournisseur(Fournisseur fournisseur)
    {
        Task.Run(async () => await HttpClientService.PutFournisseur(fournisseur));
    }

}
