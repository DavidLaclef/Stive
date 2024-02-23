using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class FamillesViewModel : BaseViewModel
{
    public ObservableCollection<FamilleLightDto> ListFamilleLights { get; set; } = new();

    public int NombreFamilles { get => ListFamilleLights.Count(); }

    private Famille _familleSelected = new();
    public Famille FamilleSelected { 
        get => _familleSelected;
        set
        {
            _familleSelected = value;
            OnPropertyChanged(nameof(FamilleSelected));
        }
    }

    public FamillesViewModel()
    {
        LoadFamilles();
    }

    public void LoadFamilles()
    {
        ListFamilleLights.Clear();
        OnPropertyChanged(nameof(NombreFamilles));

        Task.Run(async () =>
        {
            return await HttpClientService.GetFamilleLights();
        }).ContinueWith(t =>
        {
            foreach (var FamilleLight in t.Result)
            {
                ListFamilleLights.Add(FamilleLight);
            }
            OnPropertyChanged(nameof(NombreFamilles));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void AjouterFamille(Famille newFamille)
    {
        Task.Run(async () => await HttpClientService.PostFamille(newFamille));
    }
    
    public void ChargerFamille(int Id)
    {
        Task.Run(async () => await HttpClientService.GetFamilleById(Id)).ContinueWith(p =>
        {
            FamilleSelected = new Famille
            {
                Id = p.Result.Id,
                Nom = p.Result.Nom
            };
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void SupprimerFamille(int Id)
    {
        Task.Run(async () => await HttpClientService.DeleteFamille(Id));
    }

    public void ModifierFamille(Famille famille)
    {
        Task.Run(async () => await HttpClientService.PutFamille(famille));
    }


}
