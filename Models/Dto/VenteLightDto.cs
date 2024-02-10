using Models.Dao;
using Models.Enums;

namespace Models.Dto;

public class VenteLightDto
{
    public int Id { get; set; }

    public string NumeroVente { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public LieuVente Lieu { get; set; }

    public StatutMouvement Statut { get; set; } = StatutMouvement.EnAttente;
}
