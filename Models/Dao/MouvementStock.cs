using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class MouvementStock
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string NumeroMouvement { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int Quantite { get; set; }

    // La remise peut être null car il peut y en avoir une... ou non
    [Column(TypeName = "decimal(5,2)")] // 5 chiffres au total, dont 2 après la virgule
    public decimal? Remise { get; set; }

    [Required]
    public StatutMouvement Statut { get; set; } = StatutMouvement.EnAttente;

    [ForeignKey(nameof(Produit))]
    public int? ProduitId { get; set; }
    public virtual Produit? Produit { get; set; }

    public virtual ICollection<MouvementStock>? ListeMouvementStock { get; set; }
}
