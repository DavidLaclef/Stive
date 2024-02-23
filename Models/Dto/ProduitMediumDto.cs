using Models.Enums;

namespace Models.Dto;


public class ProduitMediumDto
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public int Quantite { get; set; }

    public ChateauLightDto? Chateau { get; set; }

    public ICollection<FamilleLightDto>? Familles { get; set; }

    public string FamillesConcatenees { get; set; } = string.Empty;
}
