using Models.Dao;

namespace Models.Dto;

public class ClientDto
{
    public int Id { get; set; }

    public string CodeClient { get; set; } = string.Empty;

    public string Nom { get; set; } = string.Empty;

    public string Prenom {  get; set; } = string.Empty;

    public string AdresseMail { get; set; } = string.Empty;

    public string MotDePasse { get; set; } = string.Empty;

    public string Entreprise { get; set; } = string.Empty;

    public string NumeroTelephone { get; set; } = string.Empty;

    public string NomLivraison { get; set; } = string.Empty;

    public string PrenomLivraison { get; set; } = string.Empty;

    public string DateNaissance { get; set; } = string.Empty;

    public string AdressePostale { get; set; } = string.Empty;

    public string CodePostal { get; set; } = string.Empty;

    public string Ville { get; set; } = string.Empty;

    public string InstructionLivraison { get; set; } = string.Empty;

    public ICollection<VenteLightDto>? Ventes { get; set; }
}