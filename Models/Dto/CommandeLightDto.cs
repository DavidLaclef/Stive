using Models.Enums;

namespace Models.Dto;

public class CommandeLightDto
{
    public int Id { get; set; }

    public string NumeroCommande { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public string NomFournisseur { get; set; } = string.Empty;

    public StatutMouvement Statut { get; set; }
}
