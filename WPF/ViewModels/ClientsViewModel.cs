using Models.Dao;
using Models.Dto;
using System.Collections.ObjectModel;
using WPF.Services;

namespace WPF.ViewModels;

public class ClientsViewModel : BaseViewModel
{
    public ObservableCollection<ClientDto> ListClient { get; set; } = new();

    public int NombreClients { get => ListClient.Count(); }

    private Client _clientSelected;

    public Client ClientSelected
    {
        get => _clientSelected;
        set
        {
            _clientSelected = value;
            OnPropertyChanged(nameof(ClientSelected));
        }
    }

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


    public void ChargerClient(int Id)
    {
        Task.Run(async () => await HttpClientService.GetClientById(Id)).ContinueWith(p =>
        {
            ClientSelected = new Client
            {
                Id = p.Result.Id,
                Nom = p.Result.Nom,
                Prenom = p.Result.Prenom,
                AdresseMail = p.Result.AdresseMail,
                NumeroTelephone = p.Result.NumeroTelephone,
                DateNaissance = p.Result.DateNaissance,
                AdressePostale = p.Result.AdressePostale,
                CodePostal = p.Result.CodePostal,
                Ville = p.Result.Ville,
                CodeClient = p.Result.CodeClient,
                EstMembreSite = p.Result.EstMembreSite,
                MotDePasse = p.Result.MotDePasse,
                Entreprise = p.Result.Entreprise,
                NomLivraison = p.Result.NomLivraison,
                PrenomLivraison = p.Result.PrenomLivraison,
                InstructionLivraison = p.Result.InstructionLivraison
            };
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    /*    public async Task<Client> ChargerUnClient(int Id)
        {
            var response = await HttpClientService.GetClient(Id);
            return response.FirstOrDefault(); 
        }*/

}


