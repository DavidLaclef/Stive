using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enums;

namespace Models.Dao;

public class Vente : MouvementStock
{
    [Required]
    [StringLength(10)]
    public string NumeroVente { get; set; } = string.Empty;

    [Required]
    public LieuVente Lieu { get; set; }

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public virtual Client? Client { get; set; }
}
