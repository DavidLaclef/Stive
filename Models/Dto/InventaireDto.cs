namespace Models.Dto;

public class InventaireDto
{
    public int Id { get; set; }

    public string NumeroMouvement { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public ICollection<FamilleLightDto>? Familles { get; set; }

    public string FamillesConcatenees { get; set; } = string.Empty;


    public ProduitLittleDto? Produit { get; set; }

}
