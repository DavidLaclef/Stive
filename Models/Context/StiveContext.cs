using Models.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Models.Context;

// Le contexte de base de données est la classe principale qui coordonne les fonctionnalités d’Entity Framework pour un modèle de données

public class StiveContext(DbContextOptions<StiveContext> options) : IdentityDbContext<User>(options)
{
    // Définition des tables dans la BDD. ex: la classe Client devient la table Client dans la BDD
    public DbSet<Chateau> Chateau { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Commande> Commande { get; set; }
    public DbSet<CorrectionStock> CorrectionStock { get; set; }
    public DbSet<Famille> Famille { get; set; }
    public DbSet<Fournisseur> Fournisseur { get; set; }
    public DbSet<HistoriquePrix> HistoriquePrix { get; set; }
    public DbSet<MouvementStock> MouvementStock { get; set; }
    public DbSet<Personne> Personne { get; set; }
    public DbSet<Produit> Produit { get; set; }
    public DbSet<Utilisateur> Utilisateur { get; set; }
    public DbSet<Vente> Vente { get; set; }

    public DbSet<Panier> Panier { get; set; }

}

public class StiveContextFactory : IDesignTimeDbContextFactory<StiveContext>
{
    public StiveContext CreateDbContext(string[] args)
    {
        var connexionString = "server=localhost;port=3306;userid=root;password=;database=stive;";
        var optionsBuilder = new DbContextOptionsBuilder<StiveContext>();
        optionsBuilder.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString));

        return new StiveContext(optionsBuilder.Options);
    }
}
