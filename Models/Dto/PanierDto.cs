using Models.Dao;

namespace Models.Dto;

public class PanierDto
{
    public int Id { get; set; }

    public DateTime DerniereModification { get; set; }

    public virtual ICollection<ProduitDto>? Produits { get; set; }

    public User? User { get; set; }
}
