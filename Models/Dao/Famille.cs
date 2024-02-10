using Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Famille
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Nom { get; set; } = string.Empty;

    public virtual ICollection<Produit>? Produits { get; set; }

}
