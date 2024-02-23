using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class UtilisateursViewModel : BaseViewModel
{
    public ObservableCollection<UtilisateurLightDto> ListUtilisateurLights { get; set; } = new();

    private Utilisateur _utilisateurSelected = new();

    public int NombreUtilisateurs { get => ListUtilisateurLights.Count(); }

    public Utilisateur UtilisateurSelected
    {
        get => _utilisateurSelected;
        set
        {
            _utilisateurSelected = value;
            OnPropertyChanged(nameof(UtilisateurSelected));
        }
    }

    public UtilisateursViewModel()
    {
        LoadUtilisateurs();
    }

    public void LoadUtilisateurs()
    {
        ListUtilisateurLights.Clear();
        OnPropertyChanged(nameof(NombreUtilisateurs));

        Task.Run(async () =>
        {
            return await HttpClientService.GetUtilisateurLights();
        }).ContinueWith(t =>
        {
            foreach (var UtilisateurLight in t.Result)
            {
                ListUtilisateurLights.Add(UtilisateurLight);
            }
            OnPropertyChanged(nameof(NombreUtilisateurs));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    public void AjouterUtilisateur(Utilisateur newUtilisateur)
    {
        Task.Run(async () => await HttpClientService.PostUtilisateur(newUtilisateur));
    }
    public void SupprimerUtilisateur(int Id)
    {
        Task.Run(async () => await HttpClientService.DeleteUtilisateur(Id));
    }

    public void ChargerUtilisateur(int Id)
    {
        Task.Run(async () => await HttpClientService.GetUtilisateurById(Id)).ContinueWith(t =>
        {
            UtilisateurSelected = new Utilisateur {
            Id = t.Result.Id,
            Nom = t.Result.Nom,
            Prenom = t.Result.Prenom,
            AdresseMail = t.Result.AdresseMail,
            EstGerant = t.Result.EstGerant,
            CodeUtilisateur = t.Result.CodeUtilisateur,
            MotDePasse = t.Result.MotDePasse
            };
        }, TaskScheduler.FromCurrentSynchronizationContext());
    } 

}
