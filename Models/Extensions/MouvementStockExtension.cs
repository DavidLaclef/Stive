using Models.Dao;
using Models.Dto;
using System.Net.NetworkInformation;

namespace Models.Extensions;

public static class MouvementStockExtension
{
    public static MouvementStockDto ToDto(this MouvementStock mouvementStock)
    {
        return new MouvementStockDto
        {
            Id = mouvementStock.Id,
            NumeroMouvement = mouvementStock.NumeroMouvement,
            Date = mouvementStock.Date.ToString("dd MMM yyyy"),
            Quantite = mouvementStock.Quantite,
            Statut = mouvementStock.Statut,
            Produit = mouvementStock.Produit?.ToLittleDto()
        };
    }

  public static MouvementStockMediumDto ToMediumDto (this MouvementStock mouvementStock)
    {
        return new MouvementStockMediumDto
        {
            Id = mouvementStock.Id,
            NumeroMouvement = mouvementStock.NumeroMouvement,
            Date = mouvementStock.Date.ToString("dd MM yyyy"),
            Produit = mouvementStock.Produit?.ToMediumDto()
        };
    }

    public static MouvementStockLightDto ToLightDto(this MouvementStock mouvementStock)
    {
        return new MouvementStockLightDto
        {
            Id = mouvementStock.Id,
            NumeroMouvement = mouvementStock.NumeroMouvement,
            Date = mouvementStock.Date.ToString("dd MMM yyyy"),
            Quantite = mouvementStock.Quantite,
            Statut = mouvementStock.Statut
        };
    }


}
