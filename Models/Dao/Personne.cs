using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public abstract class Personne
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Nom { get; set; } = string.Empty;

    [Required]
    [StringLength(80)]
    public string Prenom { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string AdresseMail { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string MotDePasse { get; set; } = string.Empty;

}
