using Models.Enums;

namespace Models.Dto;

public class CorrectionStockDto
{
    public int Id { get; set; }

    public string NumeroMouvement { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public int Quantite { get; set; }

    //public string NomProduit { get; set; } = string.Empty;

    public string Nature { get; set; } = string.Empty;

    public ProduitLittleDto? Produit {  get; set; }
}
