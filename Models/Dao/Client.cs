using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Client : Personne
{
    [Required]
    [StringLength(10)]
    public string CodeClient { get; set; } = string.Empty;

    [StringLength(80, ErrorMessage = "Le nom de l'entreprise ne peut dépasser 80 caractères.")]
    //[MinLength(2, ErrorMessage = "Le nom de l'entreprise doit comporter au moins 2 caractères.")]
    public string Entreprise { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le numéro de téléphone est requis.")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Le numéro de téléphone doit comporter exactement 10 chiffres.")]
    public string NumeroTelephone { get; set; } = string.Empty;

    [StringLength(80, ErrorMessage = "Le nom de livraison ne peut dépasser 80 caractères.")]
    //[MinLength(3, ErrorMessage = "Le nom de livraison doit comporter au moins 3 caractères.")]
    public string NomLivraison { get; set; } = string.Empty;

    [StringLength(80, ErrorMessage = "Le prénom de livraison ne peut dépasser 80 caractères.")]
    //[MinLength(3, ErrorMessage = "Le prénom de livraison doit comporter au moins 3 caractères.")]
    public string PrenomLivraison { get; set; } = string.Empty;

    [Required(ErrorMessage = "La date de naissance est requise.")]
    public DateTime DateNaissance { get; set; }

    [Required(ErrorMessage = "L'adresse postale est requise.")]
    [StringLength(150, ErrorMessage = "L'adresse postale ne peut dépasser 150 caractères.")]
    [MinLength(5, ErrorMessage = "L'adresse postale doit comporter au moins 5 caractères.")]
    public string AdressePostale { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le code postal est requis.")]
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Le code postal doit comporter exactement 5 chiffres.")]
    public string CodePostal { get; set; } = string.Empty;

    [Required(ErrorMessage = "La commune est requise.")]
    [StringLength(80, ErrorMessage = "La commune ne peut dépasser 80 caractères.")]
    [MinLength(3, ErrorMessage = "La commune doit comporter au moins 3 caractères.")]
    public string Ville { get; set; } = string.Empty;

    [StringLength(150, ErrorMessage = "L'instruction de livraison ne peut dépasser 150 caractères.")]
    public string InstructionLivraison { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le statut du client est requis.")]
    public bool EstMembreSite { get; set; } = false;

    public virtual ICollection<Vente>? Ventes { get; set; }
}
