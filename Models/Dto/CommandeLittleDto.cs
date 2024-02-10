using Models.Enums;

namespace Models.Dto;

public class CommandeLittleDto
{
    public int Id { get; set; }

    public string NumeroCommande { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public StatutMouvement Statut { get; set; }
}