using Models.Dao;

namespace Models.Dto;

public class FournisseurDto
{
    public int Id { get; set; }

    public string CodeFournisseur { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string AdresseMail { get; set; } = string.Empty;

    public string NumeroTelephone { get; set; } = string.Empty;

    public ICollection<CommandeLittleDto>? Commandes { get; set; }
}
