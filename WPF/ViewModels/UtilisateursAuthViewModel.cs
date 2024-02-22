using WPF.Services;

namespace WPF.ViewModels;

public class UtilisateursAuthViewModel
{
    public void AuthentifierUtilisateur(string email, string mdp)
    {
        Task.Run(async () => await HttpClientService.Login(email, mdp));
    }    
    
    public void EnregistrerUtilisateur(string email, string mdp)
    {
        Task.Run(async () => await HttpClientService.Register(email, mdp));
    }
}
