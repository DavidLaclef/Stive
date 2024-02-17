using System.ComponentModel.DataAnnotations;

namespace Models.Dao;

public class CorrectionStock : MouvementStock
{
    [Required(ErrorMessage = "La précision de la nature d'une correction de stock est obligatoire.")]
    [StringLength(200, ErrorMessage = "La nature d'une correction de stock ne peut dépasser 200 caractères.")]
    [MinLength(5, ErrorMessage = "La nature d'une correction doit comporter au moins 5 caractères.")]
    public string Nature { get; set; } = string.Empty;
}
