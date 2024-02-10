using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class HistoriquePrix
{
    public int Id { get; set; }

    [Required]
    public DateTime DateDebut { get; set; }

    // N'est pas requis
    public DateTime DateFin { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")] // 9 chiffres au total, dont 2 après la virgule
    public decimal PrixUnitaireVente { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonVente { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonCommande { get; set; }

    [ForeignKey(nameof(Produit))]
    public int ProduitId { get; set; }
    public virtual Produit? Produit { get; set; }

}
