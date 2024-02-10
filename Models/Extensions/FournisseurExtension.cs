using Models.Dao;
using Models.Dto;

namespace Models.Extensions;
public static class FournisseurExtension
{
    public static FournisseurDto ToDto(this Fournisseur fournisseur)
    {
        var fournisseurDto = new FournisseurDto
        {
            Id = fournisseur.Id,
            CodeFournisseur = fournisseur.CodeFournisseur,
            Nom = fournisseur.Nom,
            AdresseMail = fournisseur.AdresseMail,
            NumeroTelephone = fournisseur.NumeroTelephone,
            Commandes = new List<CommandeLittleDto>()
        };

        if (fournisseur.Commandes != null)
        {
            foreach (var commande in fournisseur.Commandes)
            {
                CommandeLittleDto commandeLittleDto = commande.ToLittleDto();
                fournisseurDto.Commandes?.Add(commandeLittleDto);
            }
        }
        return fournisseurDto;
    }

    public static FournisseurLightDto ToLightDto(this Fournisseur fournisseur)
    {
        return new FournisseurLightDto
        {
            Id = fournisseur.Id,
            CodeFournisseur = fournisseur.CodeFournisseur,
            Nom = fournisseur.Nom,
            AdresseMail = fournisseur.AdresseMail,
            NumeroTelephone = fournisseur.NumeroTelephone
        };
    }

    public static FournisseurLittleDto ToLittleDto(this Fournisseur fournisseur)
    {
        return new FournisseurLittleDto
        {
            Id = fournisseur.Id,
            CodeFournisseur = fournisseur.CodeFournisseur,
            Nom = fournisseur.Nom,
        };
    }
}
