namespace Models.Dto;

public class FournisseurLightDto
{
    public int Id { get; set; }

    public string CodeFournisseur { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string AdresseMail { get; set; } = string.Empty;

    public string NumeroTelephone { get; set; } = string.Empty;
}
