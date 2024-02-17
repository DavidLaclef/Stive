using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;


namespace WPF.ViewModels;

public class ClientsViewModel : BaseViewModel
{
    public ObservableCollection<ClientLightDto> ListClientLights { get; set; } = new();

    public int NombreClients { get => ListClientLights.Count(); }

    public ClientsViewModel()
    {
        LoadClients();
    }

    public void LoadClients()
    {
        ListClientLights.Clear();
        OnPropertyChanged(nameof(NombreClients));

        Task.Run(async () =>
        {
            return await HttpClientService.GetClientLights() ;
        }).ContinueWith(t =>
        {
            foreach (var ClientLight in t.Result)
            {
                ListClientLights.Add(ClientLight);
            }   
            OnPropertyChanged(nameof(NombreClients));
        }, TaskScheduler.FromCurrentSynchronizationContext() ) ; 
    }

    public void AjouterClient(Client newClient)
    {
        Task.Run(async () => await HttpClientService.PostClient(newClient));
    }
}


