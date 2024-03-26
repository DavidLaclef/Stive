using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Newtonsoft.Json;
using System.Net;

namespace Web.Controllers;

public class ProduitsController : Controller
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

    // Récupération des produits via l'API
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

    // Action
    public async Task<IActionResult> Index()
    {
        return View(await GetProduitLights());
    }


}
