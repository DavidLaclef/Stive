using Models.Dao;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class ClientsViewModel : BaseViewModel
{
    public ObservableCollection<Client> ListClient { get; set; } = new();

    public int NombreClients { get => ListClient.Count(); }

    public ClientsViewModel()
    {
        LoadClients();
    }

    public void LoadClients()
    {
        ListClient.Clear();
        OnPropertyChanged(nameof(NombreClients));

        Task.Run(async () =>
        {
            return await HttpClientService.GetClientLights();
        }).ContinueWith(t =>
        {
            foreach (var Client in t.Result)
            {
                ListClient.Add(Client);
            }
            OnPropertyChanged(nameof(NombreClients));
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    public void AjouterClient(Client newClient)
    {
        Task.Run(async () => await HttpClientService.PostClient(newClient));
    }

    public void SupprimerClient(int Id)
    {
        Task.Run(async () => await HttpClientService.DeleteClient(Id));
    }

    public void ModifierClient(int Id)
    {
        Task.Run(async () => await HttpClientService.PutClient(Id));
    }

    /*    public async Task<Client> ChargerUnClient(int Id)
        {
            var response = await HttpClientService.GetClient(Id);
            return response.FirstOrDefault(); 
        }*/

}


