using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Fournisseur
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string CodeFournisseur { get; set; } = string.Empty;

    [Required]
    [StringLength(80)]
    public string Nom { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string AdresseMail { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string NumeroTelephone {  get; set; } = string.Empty;

    public virtual ICollection<Commande>? Commandes { get; set; }

}
