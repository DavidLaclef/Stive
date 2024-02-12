using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Client : Personne
{
    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string CodeClient { get; set; } = string.Empty;

    [StringLength(80, MinimumLength = 3)]
    public string Entreprise { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string NumeroTelephone { get; set; } = string.Empty;

    [StringLength(80, MinimumLength = 3)]
    public string NomLivraison { get; set; } = string.Empty;

    [StringLength(80, MinimumLength = 3)]
    public string PrenomLivraison { get; set; } = string.Empty;

    [Required]
    public DateTime DateNaissance { get; set; }

    [Required]
    [StringLength(150)]
    public string AdressePostale { get; set; } = string.Empty;

    [Required]
    [StringLength(5, MinimumLength = 5)]
    public string CodePostal { get; set; } = string.Empty;

    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string Ville { get; set; } = string.Empty;

    [StringLength(150)]
    public string InstructionLivraison { get; set; } = string.Empty;

    [Required]
    public bool EstMembreSite { get; set; } = false;

    public virtual ICollection<Vente>? Ventes { get; set; }
}
