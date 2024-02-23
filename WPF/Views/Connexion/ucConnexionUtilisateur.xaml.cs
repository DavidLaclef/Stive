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

    // Récupération de la valeur du champ motdepasse
    private async void connecter_Click(object sender, RoutedEventArgs e)
    {
        var vm = (UtilisateursAuthViewModel)this.DataContext;
        //EstConnecte = await vm.AuthentifierUtilisateur(email.Text, motdepasse.Text);
        EstConnecte = await vm.AuthentifierUtilisateur(email.Text, motdepasse.Password);
        if (EstConnecte) ConnexionChange?.Invoke(this, EventArgs.Empty);
    }
}
