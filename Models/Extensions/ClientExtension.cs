using Models.Dao;
using Models.Dto;
using System.Globalization;
using System.Runtime.Serialization;

namespace Models.Extensions;

public static class ClientExtension
{
    public static ClientDto ToDto(this Client client)
    {
        // Formatage des données culturelles (dates, nombres, etc.)
        //CultureInfo cultureInfo = new("fr-FR");

        var clientDto = new ClientDto
        {
            Id = client.Id,
            CodeClient = client.CodeClient,
            Nom = client.Nom,
            Prenom = client.Prenom,
            AdresseMail = client.AdresseMail,
            MotDePasse = client.MotDePasse,
            Entreprise = client.Entreprise,
            NumeroTelephone = client.NumeroTelephone,
            NomLivraison = client.NomLivraison,
            PrenomLivraison = client.PrenomLivraison,
            //DateNaissance = client.DateNaissance.ToString("dd MMM yyyy", cultureInfo), // 1983-11-03T01:00:00 => 03 Nov 1983
            DateNaissance = client.DateNaissance.ToString("dd MMM yyyy"), // 1983-11-03T01:00:00 => 03 Nov 1983
            AdressePostale = client.AdressePostale,
            CodePostal = client.CodePostal,
            Ville = client.Ville,
            InstructionLivraison = client.InstructionLivraison,
            Ventes = new List<VenteLightDto>()
        };

        if (client.Ventes != null)
        {
            foreach (var vente in client.Ventes)
            {
                VenteLightDto venteDto = vente.ToLightDto();
                clientDto.Ventes.Add(venteDto);
            }
        }

        return clientDto;
    }

    // Exemple d'utilisation : affichage de la liste des clients sur la d'administration des clients
    public static ClientLightDto ToLightDto(this Client client)
    {
        return new ClientLightDto
        {
            Id = client.Id,
            CodeClient = client.CodeClient,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Entreprise = client.Entreprise,
            AdresseMail = client.AdresseMail,
            CodePostal = client.CodePostal
        };
    }

    // Exemple d'utilisation : dans l'objet Vente
    public static ClientLittleDto ToLittleDto(this Client client)
    {
        return new ClientLittleDto
        {
            Id = client.Id,
            CodeClient = client.CodeClient,
            Nom = client.Nom,
            Prenom = client.Prenom,
        };
    }
}
