using Models.Enums;
using Models.Dao;

namespace Models.Dto;

public class CommandeDto
{
    public int Id { get; set; }

    public string NumeroCommande { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public decimal? Remise { get; set; }

    public int Quantite { get; set; }

    public FournisseurLittleDto? Fournisseur { get; set; }

    public StatutMouvement Statut { get; set; }

    public ICollection<MouvementStockDto>? ListeMouvementStock { get; set; }
}
