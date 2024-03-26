using Models.Dao;
using Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Dto;

public class ProduitLightDto
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public string Millesime { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [DisplayName("Quantité en stock")]
    public int Quantite { get; set; }

    public int QuantiteReapprovisionnement { get; set; }

    public int SeuilReapprovisionnement { get; set; }

    [DisplayName("Disponibilité de la bouteille")]
    public StatutProduit Statut { get; set; }

    [DisplayName("Prix à l'unité")]
    public decimal PrixUnitaireVente { get; set; }

    [DisplayName("Prix au carton (lot de 6)")]
    public decimal PrixCartonVente { get; set; }

    public decimal PrixCartonCommande { get; set; }

    [DisplayName("Château")]
    public ChateauLightDto? Chateau { get; set; }

    [DisplayName("Famille(s)")]
    public ICollection<FamilleLightDto>? Familles { get; set; }

    public string FamillesConcatenees { get; set; } = string.Empty;

}
