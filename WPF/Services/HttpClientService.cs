using Models.Dao;
using Models.Dto;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WPF.ModelsWPF;

namespace WPF.Services;

public static class HttpClientService
{
    private const string baseAddress = "https://localhost:7080/";
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
    public static async Task<bool> Login(string email, string mdp)
    {
        string route = "login?useCookies=true&useSessionCookies=true";
        var jsonString = JsonConvert.SerializeObject(new LoginUser
        {
            Email = email,
            Password = mdp
        });

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(route, httpContent);

        var cookies = cookieContainer.GetCookies(new Uri(baseAddress));
        Debug.WriteLine(cookies);

        return response.IsSuccessStatusCode ? true :
            throw new Exception(response.ReasonPhrase);
    } 
    
    // Enregistrement des utilisateurs
    public static async Task<bool> Register(string email, string mdp)
    {
        string route = "register";
        var jsonString = JsonConvert.SerializeObject(new LoginUser
        {
            Email = email,
            Password = mdp
        });

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(route, httpContent);

        return response.IsSuccessStatusCode ? true :
            throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<ChateauLightDto>> GetChateauLights()
    {
        string uri = "api/Chateaux";
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
        string uri = $"api/Chateaux/{Id}";
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
        string uri = $"api/Chateaux/{chateau.Id}";
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
        string uri = "api/Chateaux";
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
        string route = $"api/Chateaux/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<List<ClientDto>> GetClientLights()
    {
        string uri = "api/Clients";
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
        string uri = "api/Clients";
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
        string route = $"api/Clients/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<Client> GetClientById(int Id)
    {
        string uri = $"api/Clients/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Client>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<CommandeDto>> GetCommandeLights()
    {
        string uri = "api/Commandes";
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
        string uri = "api/Familles";
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
        string uri = "api/Familles";
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
        string route = $"api/Familles/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }


    public static async Task<Chateau> GetFamilleById(int Id)
    {
        string uri = $"api/Familles/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Chateau>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }   


    public static async Task<List<FournisseurLightDto>> GetFournisseurLights()
    {
        string uri = "api/Fournisseurs";
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
        string uri = "api/Fournisseurs";
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
        string route = $"api/Fournisseurs/{id}";
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

    public static async Task<Utilisateur> GetUtilisateurById(int Id)
    {
        string uri = $"api/Chateaux/{Id}";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Utilisateur>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<UtilisateurLightDto>> GetUtilisateurLights()
    {
        string uri = "api/Utilisateurs";
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
        string uri = "api/Utilisateurs";
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
        string route = $"api/Utilisateurs/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<List<MouvementStockMediumDto>> GetMouvementStockMedium()
    {
        string uri = "api/MouvementsStock/Medium";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<MouvementStockMediumDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<MouvementStockLightDto>> GetMouvementStockLights()
    {
        string uri = "api/MouvementsStock";
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
        string uri = "api/MouvementsStock";
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
        string uri = "api/Produits";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProduitLightDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<List<ProduitMediumDto>> GetProduitMedium()
    {
        string uri = "api/Produits/Medium";
        var response = await Client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProduitMediumDto>>(result) ?? throw new FormatException($"Erreur Http : {uri}");
        }
        throw new Exception(response.ReasonPhrase);
    }

    public static async Task<bool> PostProduit(Produit produit)
    {
        string uri = "api/Produits";
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
        string route = $"api/Produits/{produitId}";
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
        string route = $"api/Produits/{id}";
        var response = await Client.DeleteAsync(route);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task PutProduit(Produit produit)
    {
        string route = $"api/Produits/{produit.Id}";

        string json = JsonConvert.SerializeObject(produit);
        var buffer = Encoding.UTF8.GetBytes(json);

        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        HttpResponseMessage response = await Client.PutAsync(route, byteContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"{response.ReasonPhrase}");
        }
    }


}
