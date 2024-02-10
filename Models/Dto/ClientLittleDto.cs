using Models.Dao;

namespace Models.Dto;

public class ClientLittleDto
{
    public int Id { get; set; }

    public string CodeClient { get; set; } = string.Empty;  

    public string Nom { get; set; } = string.Empty;

    public string Prenom {  get; set; } = string.Empty;

}