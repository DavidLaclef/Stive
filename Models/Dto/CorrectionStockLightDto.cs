namespace Models.Dto;

public class CorrectionStockLightDto
{
    public int Id { get; set; }

    public string Date { get; set; } = string.Empty;

    public int Quantite { get; set; }

    public ProduitLittleDto? Produit { get; set; }
}
