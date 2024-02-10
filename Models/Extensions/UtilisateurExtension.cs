using Models.Dao;
using Models.Dto;

namespace Models.Extensions;

public static class UtilisateurExtension
{
    public static UtilisateurDto ToDto(this Utilisateur utilisateur)
    {
        return new UtilisateurDto
        {
            Id = utilisateur.Id,
            CodeUtilisateur = utilisateur.CodeUtilisateur,
            Nom = utilisateur.Nom,
            Prenom = utilisateur.Prenom,
            AdresseMail = utilisateur.AdresseMail,
            MotDePasse = utilisateur.MotDePasse,
            EstGerant = utilisateur.EstGerant
        };
    }

    public static UtilisateurLightDto ToLightDto(this Utilisateur utilisateur)
    {
        return new UtilisateurLightDto
        {
            Id = utilisateur.Id,
            CodeUtilisateur = utilisateur.CodeUtilisateur,
            Nom = utilisateur.Nom,
            Prenom = utilisateur.Prenom,
        };
    }
}
