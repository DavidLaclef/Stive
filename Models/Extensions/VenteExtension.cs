using Models.Dao;
using Models.Dto;

namespace Models.Extensions;

public static class VenteExtension
{
    public static VenteDto ToDto(this Vente vente)
    {

        var venteDto = new VenteDto
        {
            Id = vente.Id,
            NumeroVente = vente.NumeroMouvement,
            Date = vente.Date.ToString("dd MMM yyyy"),
            Lieu = vente.Lieu,
            Quantite = vente.Quantite,
            Remise = vente.Remise,
            Statut = vente.Statut,
            Client = vente.Client?.ToLittleDto(),
            ListeMouvementStock = new List<MouvementStockDto>(),
        };

        if (vente.ListeMouvementStock != null )
        {
            foreach (var mouvement in vente.ListeMouvementStock)
            {
                MouvementStockDto mouvementStockDto = mouvement.ToDto();
                venteDto.ListeMouvementStock.Add(mouvementStockDto);
            }
        }

        return venteDto;
    }

    public static VenteLightDto ToLightDto(this Vente vente)
    {
        return new VenteLightDto
        {
            Id = vente.Id,
            NumeroVente = vente.NumeroMouvement,
            Date = vente.Date.ToString("dd MMM yyyy"),
            Lieu = vente.Lieu,
            Statut = vente.Statut
        };
    }
}
