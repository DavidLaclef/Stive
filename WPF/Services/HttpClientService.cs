using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models.Dao;
using Models.Dto;
using Newtonsoft.Json;


namespace WPF.Services
{
    public static class HttpClientService
    {
        private const string baseAddress = "https://localhost:7080/api/";
        private static HttpClient? client = null;
        private static HttpClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new() { BaseAddress = new Uri(baseAddress) };
                }
                return client;
            }
        }
        //demande metier genre les liste en fonctions des date etc ou en fonction  du statut
        public static async Task<List<ChateauLightDto>> GetChateauLights()
        {
            string uri = "Chateaux";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ChateauLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> PostChateau(Chateau chateau)
        {
            string uri = "Chateaux";
            var json = JsonConvert.SerializeObject(chateau);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<List<ClientLightDto>> GetClientLights()
        {
            string uri = "Clients";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ClientLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        // methode pour les post
        public static async Task<bool> PostClient(Client client)
        {
            string uri = "Clients";
            var json = JsonConvert.SerializeObject(client);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task DeleteClient(int id)
        {
            string route = $"Clients/{id}";
            var response = await Client.DeleteAsync(route);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }


        public static async Task<List<CommandeDto>> GetCommandeLights()
        {
            string uri = "Commandes";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CommandeDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<List<FamilleLightDto>> GetFamilleLights()
        {
            string uri = "Familles";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FamilleLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> PostFamille(Famille famille)
        {
            string uri = "Familles";
            var json = JsonConvert.SerializeObject(famille);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<List<FournisseurLightDto>> GetFournisseurLights()
        {
            string uri = "Fournisseurs";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FournisseurLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> PostFournisseur(Fournisseur fournisseur)
        {
            string uri = "Fournisseurs";
            var json = JsonConvert.SerializeObject(fournisseur);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<List<UtilisateurLightDto>> GetUtilisateurLights()
        {
            string uri = "Utilisateurs";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UtilisateurLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> PostUtilisateur(Utilisateur utilisateur)
        {
            string uri = "Utilisateurs";
            var json = JsonConvert.SerializeObject(utilisateur);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception(response.ReasonPhrase);
        }


        public static async Task<List<MouvementStockLightDto>> GetMouvementStockLights()
        {
            string uri = "MouvementsStock";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<MouvementStockLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<List<ProduitLightDto>> GetProduitLights()
        {
            string uri = "Produits";
            var response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProduitLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> PostProduit(Produit produit)
        {
            string uri = "Produits";
            var json = JsonConvert.SerializeObject(produit);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            throw new Exception(response.ReasonPhrase);
        }

    }
}
