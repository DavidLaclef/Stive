using System.Windows;
using System.Windows.Controls;
using WPF.ViewModels;

namespace WPF.Views.Connexion;

public partial class ucConnexionUtilisateur : UserControl
{
    public bool EstConnecte { get; set; }

    public event EventHandler<EventArgs>? ConnexionChange;

    public ucConnexionUtilisateur()
    {
        InitializeComponent();
    }

    private async void connecter_Click(object sender, RoutedEventArgs e)
    {
        var vm = (UtilisateursAuthViewModel)this.DataContext;
        EstConnecte = await vm.AuthentifierUtilisateur(email.Text, motdepasse.Text);

        if (EstConnecte) { ConnexionChange?.Invoke(this, EventArgs.Empty); }
    }
}
