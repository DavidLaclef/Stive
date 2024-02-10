using Models.Dao;
using Models.Dto;

namespace Models.Extensions;
public static class CorrectionStockExtension
{
    public static CorrectionStockDto ToDto(this CorrectionStock correctionStock)
    {
        return new CorrectionStockDto
        {
            Id = correctionStock.Id,
            NumeroMouvement = correctionStock.NumeroMouvement,
            Date = correctionStock.Date.ToString("dd MMM yyyy"),
            Quantite = correctionStock?.Quantite ?? 0,
            Nature = correctionStock?.Nature ?? string.Empty,
            Produit = correctionStock?.Produit?.ToLittleDto(),
        };
    }

    public static CorrectionStockLightDto ToLightDto(this CorrectionStock correctionStock)
    {
        return new CorrectionStockLightDto
        {
            Id= correctionStock.Id,
            Date = correctionStock.Date.ToString("dd MMM yyyy"),
            Quantite = correctionStock.Quantite,
            //NomProduit = correctionStock.Produit?.Nom ?? string.Empty,
            Produit = correctionStock?.Produit?.ToLittleDto(),
        };
    }
}
