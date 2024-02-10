using Models.Dao;
using Models.Dto;

namespace Models.Extensions;

public static class ChateauExtension
{
    public static ChateauDto ToDto(this Chateau chateau)
    {
        var chateauDto = new ChateauDto()
        {
            Id = chateau.Id,
            Nom = chateau.Nom,
            Produits = new List<ProduitLittleDto>()
        };

        if (chateau.Produits != null)
        {
            foreach (var produit in chateau.Produits)
            {
                ProduitLittleDto produitLittleDto = produit.ToLittleDto();
                chateauDto.Produits?.Add(produitLittleDto);
            }
        }

        return chateauDto;
    }

    public static ChateauLightDto ToLightDto(this Chateau chateau)
    {
        return new ChateauLightDto
        {
            Id = chateau.Id,
            Nom = chateau.Nom
        };
    }
}
