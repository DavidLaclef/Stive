using Models.Dao;
using Models.Dto;

namespace Models.Extensions;

public static class PanierExtension
{
    public static PanierDto ToDto(this Panier panier)
    {
        var panierDto = new PanierDto
        {
            Id = panier.Id,
            DerniereModification = panier.DerniereModification,
            Produits = new List<ProduitDto>(),
            User = panier.User
        };

        if (panier.Produits != null)
        {
            foreach (var produit in panier.Produits)
            {
                ProduitDto produitDto = produit.ToDto();
                panierDto.Produits.Add(produitDto);
            }
        }

        return panierDto;
    }

}
