using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;
using Models.Dao;

namespace WPF.ViewModels;

public class ChateauxViewModel : BaseViewModel
{
    public ObservableCollection<ChateauLightDto> ListChateauLights { get; set; } = new();

    public int  NombreChateaux { get => ListChateauLights.Count(); }

    public ChateauxViewModel()
    {
        LoadChateaux();
    }

    public void LoadChateaux()
    {
        ListChateauLights.Clear();
        OnPropertyChanged(nameof(NombreChateaux));

        Task.Run(async () =>
        {
            return await HttpClientService.GetChateauLights() ;
        }).ContinueWith(t =>
        {
            foreach (var ChateauLight in t.Result)
            {
                ListChateauLights.Add(ChateauLight);
            }   
            OnPropertyChanged(nameof(NombreChateaux));
        }, TaskScheduler.FromCurrentSynchronizationContext() ) ; 
    }

    public void AjouterChateau(Chateau newChateau)
    {
        Task.Run(async () => await HttpClientService.PostChateau(newChateau));
    }


    /*    internal void AjouterChateau(Client client)
        {
            throw new NotImplementedException();
        }*/
}
