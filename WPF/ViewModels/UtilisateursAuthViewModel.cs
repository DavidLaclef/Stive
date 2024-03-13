using WPF.Services;

namespace WPF.ViewModels;

public class UtilisateursAuthViewModel
{
    public async Task<bool> AuthentifierUtilisateur(string email, string mdp)
    {
        return await HttpClientService.Login(email, mdp);
    }

    public void EnregistrerUtilisateur(string email, string mdp)
    {
        Task.Run(async () => await HttpClientService.Register(email, mdp));
    }
}
