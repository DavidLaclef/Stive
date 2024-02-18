using Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Famille
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom de la famille est requis.")]
    [StringLength(30, ErrorMessage = "Le nom de la famille ne peut dépasser 30 caractères.")]
    [MinLength(3, ErrorMessage = "Le nom de la famille doit comporter au moins 3 caractères.")]
    public string Nom { get; set; } = string.Empty;

    public virtual ICollection<Produit>? Produits { get; set; }

}
