using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public abstract class Personne
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(80, ErrorMessage = "Le nom ne peut pas dépasser 80 caractères.")]
    [MinLength(3, ErrorMessage = "Le nom doit comporter au moins 3 caractères.")]
    public string Nom { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le prénom est requis.")]
    [StringLength(80, ErrorMessage = "Le prénom ne peut pas dépasser 80 caractères.")]
    [MinLength(3, ErrorMessage = "Le prénom doit comporter au moins 3 caractères.")]
    public string Prenom { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'adresse e-mail est requise.")]
    [StringLength(150, ErrorMessage = "L'adresse e-mail ne peut dépasser 150 caractères.")]
    [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
    public string AdresseMail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le mot de passe est requis.")]
    [StringLength(255, ErrorMessage = "Le mot de passe ne peut pas dépasser 255 caractères.")]
    public string MotDePasse { get; set; } = string.Empty;

}
