﻿using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;


namespace WPF.ViewModels;

public class FournisseursViewModel : BaseViewModel
{
    public ObservableCollection<FournisseurLightDto> ListFournisseurLights { get; set; } = new();

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
            return await HttpClientService.GetFournisseurLights() ;
        }).ContinueWith(t =>
        {
            foreach (var FournisseurLight in t.Result)
            {
                ListFournisseurLights.Add(FournisseurLight);
            }   
            OnPropertyChanged(nameof(NombreFournisseurs));
        }, TaskScheduler.FromCurrentSynchronizationContext() ) ; 
    }
}