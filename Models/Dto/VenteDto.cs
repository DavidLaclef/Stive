using Models.Enums;

namespace Models.Dto;

public class VenteDto
{
    public int Id { get; set; }

    public string NumeroVente { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public LieuVente Lieu { get; set; }

    public int? Quantite { get; set; }

    public decimal? Remise { get; set; }

    public StatutMouvement Statut { get; set; } = StatutMouvement.EnAttente;

    public ICollection<MouvementStockDto>? ListeMouvementStock { get; set; }

    public ClientLittleDto? Client { get; set; }

}
