using Models.Dao;
using Models.Dto;

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
    
    public static MouvementStockLightDto ToLightDto(this MouvementStock mouvementStock)
    {
        return new MouvementStockLightDto
        {
            Id = mouvementStock.Id,
            NumeroMouvement = mouvementStock.NumeroMouvement,
            Date = mouvementStock.Date.ToString("dd MMM yyyy"),
            Quantite = mouvementStock.Quantite,
            Statut = mouvementStock.Statut,
        };
    }
}
