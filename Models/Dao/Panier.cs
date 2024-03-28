using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class Panier
{
    public int Id { get; set; }

    public DateTime DerniereModification { get; set; } = DateTime.Now.Date; // .Now.Date == sans les heures, minutes et secondes

    public virtual ICollection<Produit>? Produits { get; set; }

    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
