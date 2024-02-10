using Models.Dao;

namespace Models.Dto;

public class ChateauDto
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public ICollection<ProduitLittleDto>? Produits { get; set; }
}
