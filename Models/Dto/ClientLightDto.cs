namespace Models.Dto;
public class ClientLightDto
{
    public int Id { get; set; }

    public string CodeClient { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string Prenom { get; set; } = string.Empty;

    public string Entreprise { get; set; } = string.Empty;

    public string AdresseMail { get; set; } = string.Empty;

    public string CodePostal { get; set; } = string.Empty;

}
