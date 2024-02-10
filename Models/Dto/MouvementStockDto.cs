using Models.Enums;

namespace Models.Dto;

public class MouvementStockDto
{
    public int Id { get; set; }

    public string NumeroMouvement { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public int Quantite { get; set; }

    public StatutMouvement Statut { get; set; } = StatutMouvement.EnAttente;

    public ProduitLittleDto? Produit {  get; set; }
}
