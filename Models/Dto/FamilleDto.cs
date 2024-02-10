namespace Models.Dto;

public class FamilleDto
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public ICollection<ProduitLittleDto>? Produits { get; set; }
}
