using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class Produit
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
    [MinLength(3, ErrorMessage = "Le nom doit comporter au moins 3 caractères.")]
    public string Nom { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string PhotoProduit { get; set; } = string.Empty;

    [Required(ErrorMessage = "La date du millésime est requise.")]
    public DateTime Millesime { get; set; }

    [Required(ErrorMessage = "La description est requise.")]
    [StringLength(200, ErrorMessage = "La description ne peut pas dépasser 200 caractères.")]
    [MinLength(10, ErrorMessage = "La description doit comporter au moins 10 caractères.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "La quantité est requise.")]
    public int Quantite { get; set; }

    [Required(ErrorMessage = "Le seuil de réapprovisionnement est requis.")]
    public int SeuilReapprovisionnement { get; set; } = 5;

    [Required]
    public StatutProduit Statut { get; set; } = StatutProduit.Ok;

    [Required(ErrorMessage = "Le prix unitaire de vente est requis.")]
    [Column(TypeName = "decimal(9,2)")] // 9 chiffres au total, dont 2 après la virgule
    public decimal PrixUnitaireVente { get; set; }

    [Required(ErrorMessage = "Le prix de vente du carton est requis.")]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonVente { get; set; }

    [Required(ErrorMessage = "Le prix de commande du carton est requis.")]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonCommande { get; set; }

    [ForeignKey(nameof(Chateau))]
    public int ChateauId { get; set; }
    public virtual Chateau? Chateau { get; set; }

    public virtual ICollection<HistoriquePrix>? HistoriquesPrix { get; set; }

    public virtual ICollection<Famille>? Familles { get; set; }

    public virtual ICollection<MouvementStock>? MouvementsStock { get; set; }

}
