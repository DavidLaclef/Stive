using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Fournisseur
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string CodeFournisseur { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le nom du fournisseur est requis.")]
    [StringLength(80, ErrorMessage = "Le nom du fournisseur ne peut dépasser 80 caractères.")]
    [MinLength(3, ErrorMessage = "Le nom du fournisseur doit comporter au moins 3 caractères.")]
    public string Nom { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'adresse e-mail du fournisseur est requise.")]
    [StringLength(150, ErrorMessage = "L'adresse e-mail ne peut dépasser 150 caractères.")]
    [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
    public string AdresseMail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Le numéro de téléphone doit comporter exactement 10 chiffres.")]
    public string NumeroTelephone {  get; set; } = string.Empty;

    public virtual ICollection<Commande>? Commandes { get; set; }

}
