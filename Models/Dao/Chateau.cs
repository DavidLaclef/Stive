using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Chateau
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom du château est requis.")]
    [StringLength(50, ErrorMessage = "Le nom du château ne peut dépasser 50 caractères.")]
    [MinLength(3, ErrorMessage = "Le nom du château doit comporter au moins 3 caractères.")]
    public string Nom { get; set; } = string.Empty;

    public virtual ICollection<Produit>? Produits { get; set; }
}
