using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Chateau
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nom { get; set; } = string.Empty;

    public virtual ICollection<Produit>? Produits { get; set; }
}
