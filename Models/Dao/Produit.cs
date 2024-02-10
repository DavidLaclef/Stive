using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class Produit
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nom { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string PhotoProduit { get; set; } = string.Empty;

    [Required]
    public DateTime Millesime { get; set; }

    [Required]
    [StringLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int Quantite { get; set; }

    [Required]
    public int SeuilReapprovisionnement { get; set; } = 5;

    [Required]
    public StatutProduit Statut { get; set; } = StatutProduit.Ok;

    [Required]
    [Column(TypeName = "decimal(9,2)")] // 9 chiffres au total, dont 2 après la virgule
    public decimal PrixUnitaireVente { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonVente { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonCommande { get; set; }

    [ForeignKey(nameof(Chateau))]
    public int ChateauId { get; set; }
    public virtual Chateau? Chateau { get; set; }

    public virtual ICollection<HistoriquePrix>? HistoriquesPrix { get; set; }

    public virtual ICollection<Famille>? Familles { get; set; }

    public virtual ICollection<MouvementStock>? MouvementsStock { get; set; }

}
