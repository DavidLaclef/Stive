using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class CorrectionStock : MouvementStock
{
    [Required] // L'ajout de la nature d'une correction de stock est obligatoire
    [StringLength(200)]
    public string Nature { get; set; } = string.Empty;
}
