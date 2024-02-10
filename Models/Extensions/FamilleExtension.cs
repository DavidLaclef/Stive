using Models.Dao;
using Models.Dto;

namespace Models.Extensions;

public static class FamilleExtension
{
    public static FamilleDto ToDto(this Famille famille)
    {
        var familleDto = new FamilleDto
        {
            Id = famille.Id,
            Nom = famille.Nom,
            Produits = new List<ProduitLittleDto>()

        };

        if (famille.Produits != null)
        {
            foreach (var produit in famille.Produits)
            {
                ProduitLittleDto produitLittleDto = produit.ToLittleDto();
                familleDto.Produits?.Add(produitLittleDto);
            }
        }
        return familleDto;
    }

    public static FamilleLightDto ToLightDto(this Famille famille)
    {
        return new FamilleLightDto
        {
            Id = famille.Id,
            Nom = famille.Nom
        };
    }
}
