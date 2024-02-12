﻿using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;


namespace WPF.ViewModels;

public class FamillesViewModel : BaseViewModel
{
    public ObservableCollection<FamilleLightDto> ListFamilleLights { get; set; } = new();

    public int  NombreFamilles { get => ListFamilleLights.Count(); }

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
            return await HttpClientService.GetFamilleLights() ;
        }).ContinueWith(t =>
        {
            foreach (var FamilleLight in t.Result)
            {
                ListFamilleLights.Add(FamilleLight);
            }   
            OnPropertyChanged(nameof(NombreFamilles));
        }, TaskScheduler.FromCurrentSynchronizationContext() ) ; 
    }
}