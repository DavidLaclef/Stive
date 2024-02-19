﻿using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class UtilisateursViewModel : BaseViewModel
{
    public ObservableCollection<UtilisateurLightDto> ListUtilisateurLights { get; set; } = new();

    public int NombreUtilisateurs { get => ListUtilisateurLights.Count(); }

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

}
