using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class Utilisateur : Personne
{
    [Required]
    [StringLength(10)]
    public string CodeUtilisateur { get; set; } = string.Empty;

    [Required]
    public bool EstGerant { get; set; }
}
