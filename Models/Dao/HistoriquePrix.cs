using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class HistoriquePrix
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La date de début est requise.")]
    public DateTime DateDebut { get; set; }

    // N'est pas requis
    public DateTime DateFin { get; set; }

    [Required(ErrorMessage = "Le prix unitaire de vente est requis.")]
    [Column(TypeName = "decimal(9,2)")] // 9 chiffres au total, dont 2 après la virgule
    public decimal PrixUnitaireVente { get; set; }

    [Required(ErrorMessage = "Le prix de vente du carton est requis.")]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonVente { get; set; }

    [Required(ErrorMessage = "Le prix de commande du carton est requis.")]
    [Column(TypeName = "decimal(9,2)")]
    public decimal PrixCartonCommande { get; set; }

    [ForeignKey(nameof(Produit))]
    public int ProduitId { get; set; }
    public virtual Produit? Produit { get; set; }

}
