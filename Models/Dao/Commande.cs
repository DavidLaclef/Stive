using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class Commande : MouvementStock
{
    [Required]
    [StringLength(10)]
    public string NumeroCommande { get; set; } = string.Empty;

    [ForeignKey(nameof(Fournisseur))]
    public int FournisseurId { get; set; }
    public virtual Fournisseur? Fournisseur { get; set; }
}
