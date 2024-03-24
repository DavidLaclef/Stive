using Models.Dao;
using Models.Dto;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
//using WPF.ModelsWPF;

namespace WPF.Services;

public static class HttpClientService
{
    private const string baseAddress = "https://localhost:7080/api/";
    private static HttpClient? client = null;
    private static CookieContainer cookieContainer = new();
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

    // Authentification des utilisateurs
    //public static async Task<bool> Login(string email, string mdp)
    //{
    //    string route = "login?useCookies=true&useSessionCookies=true";
    //    var jsonString = JsonConvert.SerializeObject(new LoginUser
    //    {
    //        Email = email,
    //        MotDePasse = mdp
    //    });

    //    var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
    //    var response = await Client.PostAsync(route, httpContent);

    //    var cookies = cookieContainer.GetCookies(new Uri(baseAddress));
    //    Debug.WriteLine(cookies);

    //    return response.IsSuccessStatusCode ? true :
    //        throw new Exception(response.ReasonPhrase);
    //}

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

    public static async Task<Chateau> GetChateauById(int Id)
    {
        string uri = $"Chateaux/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Chateau>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> PutChateau(Chateau chateau)
    {
        string uri = $"Chateaux/{chateau.Id}";
        var json = JsonConvert.SerializeObject(chateau);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            return true;
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

    public static async Task DeleteChateau(int id)
    {
        string route = $"Chateaux/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<List<ClientDto>> GetClientLights()
    {
        string uri = "Clients";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClientDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    /*        public static async Task<List<Client>> GetClient(int Id)
            {
                string uri = $"Clients/{Id}";
                var response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Client>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
                }
                throw new Exception(response.ReasonPhrase);
            }*/

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

    public static async Task<Client> GetClientById(int Id)
    {
        string uri = $"Clients/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Client>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> PutClient(Client client)
    {
        string uri = $"Clients/{client.Id}";
        var json = JsonConvert.SerializeObject(client);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        throw new Exception(response.ReasonPhrase);
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

    public static async Task DeleteFamille(int id)
    {
        string route = $"Familles/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }


    public static async Task<Chateau> GetFamilleById(int Id)
    {
        string uri = $"Familles/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Chateau>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> PutFamille(Famille famille)
    {
        string uri = $"Familles/{famille.Id}";
        var json = JsonConvert.SerializeObject(famille);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(uri, content);
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

    public static async Task DeleteFournisseur(int id)
    {
        string route = $"Fournisseurs/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<Fournisseur> GetFournisseurById(int Id)
    {
        string uri = $"Fournisseurs/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Fournisseur>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> PutFournisseur(Fournisseur fournisseur)
    {
        string uri = $"Fournisseurs/{fournisseur.Id}";
        var json = JsonConvert.SerializeObject(fournisseur);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(uri, content);
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

    public static async Task DeleteUtilisateur(int id)
    {
        string route = $"Utilisateurs/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<Utilisateur> GetUtilisateurById(int Id)
    {
        string uri = $"Utilisateurs/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Utilisateur>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }



    public static async Task<bool> PutUtilisateur(Utilisateur utilisateur)
    {
        string uri = $"Utilisateurs/{utilisateur.Id}";
        var json = JsonConvert.SerializeObject(utilisateur);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(uri, content);
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

    public static async Task<bool> PostMouvementStock(MouvementStock mouvementStock)
    {
        string uri = "MouvementsStock";
        var json = JsonConvert.SerializeObject(mouvementStock);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PostAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            return true;
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


    public static async Task<ProduitDto> GetProduitById(int produitId)
    {
        string route = $"Produits/{produitId}";
        var response = await Client.GetAsync(route);
        if (response.IsSuccessStatusCode)
        {
            string resultat = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProduitDto>(resultat)
                ?? throw new FormatException($"Erreur http : {route} ");
        }
        throw new Exception(response.ReasonPhrase);
    }


    public static async Task DeleteProduit(int id)
    {
        string route = $"Produits/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<bool> PutProduit(Produit produit)
    {
        string uri = $"Produits/{produit.Id}";
        var json = JsonConvert.SerializeObject(produit);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        throw new Exception(response.ReasonPhrase);
    }


}
