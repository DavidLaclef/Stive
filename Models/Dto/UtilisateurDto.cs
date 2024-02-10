namespace Models.Dto;

public class UtilisateurDto
{
    public int Id { get; set; }

    public string CodeUtilisateur { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string Prenom {  get; set; } = string.Empty;

    public string AdresseMail { get; set; } = string.Empty;

    public string MotDePasse { get; set; } = string.Empty;

    public bool EstGerant { get; set; }


}