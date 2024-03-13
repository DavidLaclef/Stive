using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dao;

public class Panier
{
    public int Id { get; set; }

    public DateTime DerniereModification { get; set; } = DateTime.Now;

    public ICollection<Produit>? Produits  { get; set; }

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;
}
