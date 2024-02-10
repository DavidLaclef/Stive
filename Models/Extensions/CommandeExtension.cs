using Models.Dao;
using Models.Dto;

namespace Models.Extensions;

public static class CommandeExtension
{
    public static CommandeDto ToDto(this Commande commande)
    {
        var commandeDto = new CommandeDto
        {
            Id = commande.Id,
            NumeroCommande = commande.NumeroMouvement,
            Date = commande.Date.ToString("dd MMM yyyy"),
            Fournisseur = commande.Fournisseur?.ToLittleDto(),
            Quantite = commande.Quantite,
            Remise = commande.Remise,
            Statut = commande.Statut,
            ListeMouvementStock = new List<MouvementStockDto>()
        };

        if (commande.ListeMouvementStock != null)
        {
            foreach (var mouvement in commande.ListeMouvementStock)
            {
                MouvementStockDto mouvementStockDto = mouvement.ToDto();
                commandeDto.ListeMouvementStock.Add(mouvementStockDto);
            }
        }

        return commandeDto;
    }

    public static CommandeLightDto ToLightDto(this Commande commande)
    {
        return new CommandeLightDto
        {
            Id = commande.Id,
            NumeroCommande = commande.NumeroMouvement,
            Date = commande.Date.ToString("dd MMM yyyy"),
            NomFournisseur = commande.Fournisseur?.Nom ?? string.Empty,
            Statut = commande.Statut
        };
    }

    public static CommandeLittleDto ToLittleDto(this Commande commande)
    {
        return new CommandeLittleDto
        {
            Id = commande.Id,
            NumeroCommande = commande.NumeroMouvement,
            Date = commande.Date.ToString("dd MMM yyyy"),
            Statut = commande.Statut
        };
    }
}
