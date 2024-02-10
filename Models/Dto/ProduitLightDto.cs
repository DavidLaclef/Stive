using Models.Dao;
using Models.Enums;

namespace Models.Dto;

public class ProduitLightDto
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public string Millesime { get; set; } = string.Empty;

    public int Quantite { get; set; }

    public int SeuilReapprovisionnement { get; set; }

    public StatutProduit Statut { get; set; }

    public decimal PrixUnitaireVente { get; set; }

    public decimal PrixCartonVente { get; set; }

    public decimal PrixCartonCommande { get; set; }

    public ChateauLightDto? Chateau { get; set; }

    public ICollection<FamilleLightDto>? Familles { get; set; }

}
