using Models.Context;
using Models.Dao;

namespace ConsoleApp;

public static class SeedService
{
    // Création d'un code aléatoire en définissant un préfixe. Utilisé pour CodeClient et CodeFournisseur
    public static string CreationCode(string prefixe) => $"{prefixe!}-{Guid.NewGuid().ToString().ToUpper().Substring(0, 6)}";

    public static void SeedDatabase()
    {
        /*
         * Crée et utilise un contexte de la base de données Stive pour effectuer les opérations CRUD sur la base de données.
         * Using garantit que les ressources associées à ce contexte sont correctement libérées à la fin de l'utilisation grâce à la construction using.
         */

        var factoryContext = new StiveContextFactory();

        using var context = factoryContext.CreateDbContext([]);

        #region Fournisseurs
        context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Tariquet", AdresseMail = "zoe@tariquet.fr", NumeroTelephone = "0686541700" });
        context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Pellehaut", AdresseMail = "margot@pelleheaut.fr", NumeroTelephone = "0623125578" });
        context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Joy", AdresseMail = "bob@joy.fr", NumeroTelephone = "0648621523" });
        context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Vignoble Fontan", AdresseMail = "nathan@fontan.fr", NumeroTelephone = "0662351145" });
        context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Uby", AdresseMail = "leonie@uby.fr", NumeroTelephone = "0603195813" });
        #endregion Fournisseurs

        #region Clients
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Belnades",
            Prenom = "Sypha",
            AdresseMail = "sypha.belnades@mail.fr",
            MotDePasse = "$2y$10$e/YYleAiaKWpKv73lbZJNO8jidopZ84XoGj4BMp8lBc/W.DaRh3dC",
            Entreprise = "Maison Belmont",
            NumeroTelephone = "0764126200",
            NomLivraison = "",
            PrenomLivraison = "",
            DateNaissance = DateTime.Parse("1995-07-25T00:00:00.000Z"),
            AdressePostale = "12 impasse des magiciens",
            CodePostal = "05671",
            Ville = "Abra Cada",
            InstructionLivraison = "",
            EstMembreSite = true
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Belmont",
            Prenom = "Trevor",
            AdresseMail = "trevor.belmont@mail.fr",
            MotDePasse = "$2y$10$J9iBZTS42hPHybGAD/eKuuv.atAnszMJjR1uAp1B37RDQUxktR36i",
            Entreprise = "Maison Belmont",
            NumeroTelephone = "0647221711",
            NomLivraison = "Tepes",
            PrenomLivraison = "Alucard",
            DateNaissance = DateTime.Parse("1983-11-03T00:00:00.000Z"),
            AdressePostale = "388 avenue du Château",
            CodePostal = "77000",
            Ville = "Lindenfeld",
            InstructionLivraison = "",
            EstMembreSite = false
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Roux",
            Prenom = "Pierre",
            AdresseMail = "pierre.roux@mail.fr",
            MotDePasse = "$2y$10$bF61ECPXybkV8fExVWci0Ohr1qS6gDmR6o/xkwEZ9HFlRQZdERe4u",
            Entreprise = "",
            NumeroTelephone = "0712345678",
            NomLivraison = "Lefevre",
            PrenomLivraison = "Sophie",
            DateNaissance = DateTime.Parse("1995-11-22T00:00:00.000Z"),
            AdressePostale = "789 Rue de la Nature",
            CodePostal = "33000",
            Ville = "Bordeaux",
            InstructionLivraison = "Livrer à l'arrière de la maison",
            EstMembreSite = true
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Morel",
            Prenom = "Eva",
            AdresseMail = "eva.morel@mail.fr",
            MotDePasse = "$2y$10$A1a8z2xRd3KDCR8TJkCg3uT1yFrG5Eos6e9e25MSBmSwsgco0A5ZG",
            Entreprise = "École de Musique",
            NumeroTelephone = "0685123456",
            NomLivraison = "Martin",
            PrenomLivraison = "Antoine",
            DateNaissance = DateTime.Parse("1987-04-30T00:00:00.000Z"),
            AdressePostale = "456 Avenue des Harmonies",
            CodePostal = "69002",
            Ville = "Lyon",
            InstructionLivraison = "Remettre le colis au gardien",
            EstMembreSite = false
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Fournier",
            Prenom = "Sophie",
            AdresseMail = "sophie.fournier@mail.fr",
            MotDePasse = "$2y$10$9t8q09o6OlG5XtvKd2sR9Or7Mvm54TNYK4zhT78H7Z7F58IAYn6nC",
            Entreprise = "Mode Chic",
            NumeroTelephone = "0712345678",
            NomLivraison = "",
            PrenomLivraison = "",
            DateNaissance = DateTime.Parse("1980-06-28T00:00:00.000Z"),
            AdressePostale = "567 Rue de la Mode",
            CodePostal = "33000",
            Ville = "Bordeaux",
            InstructionLivraison = "",
            EstMembreSite = true
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Moreau",
            Prenom = "Lucas",
            AdresseMail = "lucas.moreau@mail.fr",
            MotDePasse = "$2y$10$Y1o3d8etTnzlT8oqf44wrO8j0efnC9eBp5XScMPN02mGPTo0fc9LS",
            Entreprise = "",
            NumeroTelephone = "0765987452",
            NomLivraison = "Dubois",
            PrenomLivraison = "Emma",
            DateNaissance = DateTime.Parse("1993-12-05T00:00:00.000Z"),
            AdressePostale = "234 Avenue de la Paix",
            CodePostal = "69001",
            Ville = "Lyon",
            InstructionLivraison = "Livrer à la porte arrière",
            EstMembreSite = false
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Girard",
            Prenom = "Julie",
            AdresseMail = "julie.girard@mail.fr",
            MotDePasse = "$2y$10$QxQy6Db4Z2NEp9oMPHxUa.r8wXhndWT2vG6OSJ/8p/9/MXQYNU1hq",
            Entreprise = "Studio Créatif",
            NumeroTelephone = "0687452369",
            NomLivraison = "Lefevre",
            PrenomLivraison = "Thomas",
            DateNaissance = DateTime.Parse("1989-09-18T00:00:00.000Z"),
            AdressePostale = "987 Rue de l'Art",
            CodePostal = "75012",
            Ville = "Paris",
            InstructionLivraison = "Déposer le colis à la conciergerie",
            EstMembreSite = false
        });
        context.Client.Add(new Client
        {
            CodeClient = CreationCode("CLI"),
            Nom = "Lefevre",
            Prenom = "Jean",
            AdresseMail = "jean.lefevre@mail.fr",
            MotDePasse = "$2y$10$Aq6o3G06eM5CVixb0oKoMecUpnM7Moxk1QELJfT5GUPkKmHLx.hSS",
            Entreprise = "",
            NumeroTelephone = "0655987452",
            NomLivraison = "Durand",
            PrenomLivraison = "Marjorie",
            DateNaissance = DateTime.Parse("1985-08-22T00:00:00.000Z"),
            AdressePostale = "456 Rue de la Libération",
            CodePostal = "69000",
            Ville = "Lyon",
            InstructionLivraison = "",
            EstMembreSite = false
        });
        #endregion Clients

        #region Utilisateurs
        context.Utilisateur.Add(new Utilisateur
        {
            CodeUtilisateur = CreationCode("UTI"),
            Nom = "Cleveland",
            Prenom = "Glenda",
            AdresseMail = "glenda.cleveland@mail.fr",
            MotDePasse = "$2y$10$GZSwP/4UG7RDCazJ0noJxueOnaDXZgF1I.jVbSDtF3R6a1olLL1uS",
            EstGerant = false
        });
        context.Utilisateur.Add(new Utilisateur
        {
            CodeUtilisateur = CreationCode("UTI"),
            Nom = "Imm",
            Prenom = "Leonor",
            AdresseMail = "leonor.imm@mail.fr",
            MotDePasse = "$2y$10$e/YYleAiaKWpKv73lbZJNO8jidopZ84XoGj4BMp8lBc/W.DaRh3dC",
            EstGerant = false
        });
        context.Utilisateur.Add(new Utilisateur
        {
            CodeUtilisateur = CreationCode("UTI"),
            Nom = "Lopez",
            Prenom = "Carlos",
            AdresseMail = "carlos.lopez@mail.fr",
            MotDePasse = "$2y$10$RIm04.gFmjyYoyTnFoy2Meq0Tt5aKJkwPjK6czX/otEL4XYdswCEW",
            EstGerant = false

        });
        context.Utilisateur.Add(new Utilisateur
        {
            CodeUtilisateur = CreationCode("UTI"),
            Nom = "Mastfor",
            Prenom = "Isaac",
            AdresseMail = "isaac.mastfor@mail.fr",
            MotDePasse = "$2y$10$0W4m.ExniqoAAeszAGyWF.g7oXxuHVMmj04ItmeDuNXAbuLyXnfNe",
            EstGerant = true
        });
        #endregion Utilisateurs

        #region Châteaux
        context.Chateau.Add(new Chateau { Nom = "Margaux" });
        context.Chateau.Add(new Chateau { Nom = "Lafite Rothschild" });
        context.Chateau.Add(new Chateau { Nom = "Latour" });
        context.Chateau.Add(new Chateau { Nom = "Haut-Biron" });
        context.Chateau.Add(new Chateau { Nom = "Yquem" });
        context.Chateau.Add(new Chateau { Nom = "Montrose" });
        context.Chateau.Add(new Chateau { Nom = "Palmer" });
        context.Chateau.Add(new Chateau { Nom = "Lynch-Bages" });
        #endregion Châteaux

        #region Familles
        context.Famille.Add(new Famille { Nom = "Rouge" });
        context.Famille.Add(new Famille { Nom = "Rosé" });
        context.Famille.Add(new Famille { Nom = "Blanc" });
        context.Famille.Add(new Famille { Nom = "Pétillant" });
        context.Famille.Add(new Famille { Nom = "Digestif" });
        context.SaveChanges();

        var Famille1 = context.Famille
            .Where(f => f.Id == 1)
            .FirstOrDefault();

        var Famille2 = context.Famille
            .Where(f => f.Id == 2)
            .FirstOrDefault();

        var Famille3 = context.Famille
            .Where(f => f.Id == 3)
            .FirstOrDefault();

        var Famille4 = context.Famille
            .Where(f => f.Id == 4)
            .FirstOrDefault();

        var Famille5 = context.Famille
            .Where(f => f.Id == 5)
            .FirstOrDefault();
        #endregion Familles
        context.SaveChanges();

        #region Produits
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille1!, Famille4! },
            ChateauId = 1,
            Nom = "Château Montrose",
            Quantite = 40,
            Millesime = new DateTime(2010, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 300,
            PrixCartonVente = 1650,
            PrixCartonCommande = 1200,
            Description = "Offre puissance, complexité, fruits noirs et tanins fins.",
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille2!, Famille4! },
            ChateauId = 6,
            Nom = "La Dame de Montrose",
            Quantite = 15,
            Millesime = new DateTime(2015, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 50,
            PrixCartonVente = 270,
            PrixCartonCommande = 130,
            Description = "Apporte fraîcheur, équilibre, fruits rouges et texture soyeuse."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille4!, Famille5! },
            ChateauId = 7,
            Nom = "Château Palmer",
            Quantite = 200,
            Millesime = new DateTime(2016, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 300,
            PrixCartonVente = 1550,
            PrixCartonCommande = 1300,
            Description = "Élégance, complexité florale, tanins veloutés."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille3!, Famille5! },
            ChateauId = 7,
            Nom = "Alter Ego de Palmer",
            Quantite = 3,
            Millesime = new DateTime(2018, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 70,
            PrixCartonVente = 400,
            PrixCartonCommande = 360,
            Description = "Fraîcheur, fruité, équilibre, facilité de dégustation."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille1!, Famille4! },
            ChateauId = 8,
            Nom = "Château Lynch-Bages",
            Quantite = 40,
            Millesime = new DateTime(2010, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 200,
            PrixCartonVente = 1100,
            PrixCartonCommande = 850,
            Description = "Structuré, fruits mûrs, épices, finale persistante."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille4!, Famille5! },
            ChateauId = 8,
            Nom = "Echo de Lynch-Bages",
            Quantite = 5,
            Millesime = new DateTime(2016, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 40,
            PrixCartonVente = 220,
            PrixCartonCommande = 180,
            Description = "Souplesse, fruité, tanins souples, fraîcheur agréable."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille2!, Famille4! },
            ChateauId = 1,
            Nom = "Château Margaux",
            Quantite = 60,
            Millesime = new DateTime(2016, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 900,
            PrixCartonVente = 6000,
            PrixCartonCommande = 4800,
            Description = "Raffinement, complexité, fruits noirs, tanins soyeux."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille3!, Famille5! },
            ChateauId = 1,
            Nom = "Pavillon Blanc de Château Margaux",
            Quantite = 100,
            Millesime = new DateTime(2018, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 500,
            PrixCartonVente = 2850,
            PrixCartonCommande = 2500,
            Description = "Fraîcheur, citron, minéralité, grande élégance."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille5! },
            ChateauId = 1,
            Nom = "Margaux du Château Margaux",
            Quantite = 250,
            Millesime = new DateTime(2015, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 250,
            PrixCartonVente = 1480,
            PrixCartonCommande = 1210,
            Description = "Harmonie, fruits rouges, épices douces, longueur en bouche."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille3!, Famille5! },
            ChateauId = 2,
            Nom = "Château Lafite Rothschild",
            Quantite = 0,
            Millesime = new DateTime(2010, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 1500,
            PrixCartonVente = 8700,
            PrixCartonCommande = 7350,
            Description = "Puissance, concentration, fruits noirs, tanins fins, longueur."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille4! },
            ChateauId = 2,
            Nom = "Carruades de Lafite",
            Quantite = 0,
            Millesime = new DateTime(2015, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 300,
            PrixCartonVente = 1720,
            PrixCartonCommande = 1500,
            Description = "Fraîcheur, fruits rouges, élégance, tanins souples."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille3! },
            ChateauId = 3,
            Nom = "Château Latour",
            Quantite = 97,
            Millesime = new DateTime(2005, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 1200,
            PrixCartonVente = 6980,
            PrixCartonCommande = 5860,
            Description = "Concentration, complexité, fruits noirs, tanins puissants, longue garde."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille2! },
            ChateauId = 3,
            Nom = "Les Forts de Latour",
            Quantite = 20,
            Millesime = new DateTime(2012, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 300,
            PrixCartonVente = 1770,
            PrixCartonCommande = 1590,
            Description = "Équilibre, fruits rouges, tanins soyeux, élégance."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille2!, Famille5! },
            ChateauId = 4,
            Nom = "Château Haut-Brion",
            Quantite = 40,
            Millesime = new DateTime(2010, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 900,
            PrixCartonVente = 6100,
            PrixCartonCommande = 4900,
            Description = "Profondeur, complexité, fruits noirs, notes fumées, tanins veloutés."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille1! },
            ChateauId = 4,
            Nom = "Château Haut-Brion Blanc",
            Quantite = 65,
            Millesime = new DateTime(2014, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 900,
            PrixCartonVente = 6100,
            PrixCartonCommande = 4900,
            Description = "Richesse, agrumes, minéralité, finale persistante."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille5! },
            ChateauId = 5,
            Nom = "Château d'Yquem",
            Quantite = 75,
            Millesime = new DateTime(2015, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 400,
            PrixCartonVente = 2370,
            PrixCartonCommande = 2000,
            Description = "Intensité, miel, fruits exotiques, parfait équilibre."
        });
        context.Produit.Add(new Produit
        {
            Familles = new[] { Famille3! },
            ChateauId = 5,
            Nom = "Y",
            Quantite = 5,
            Millesime = new DateTime(2018, 1, 1),
            PhotoProduit = "chemin/vers/fichier/photo.png",
            PrixUnitaireVente = 150,
            PrixCartonVente = 880,
            PrixCartonCommande = 750,
            Description = "Fraîcheur, fruits blancs, élégance, finale persistante."
        });
        #endregion Produits
        context.SaveChanges();

        #region Mouvements de Stock
        // Commande
        context.MouvementStock.Add(new MouvementStock
        {
            NumeroMouvement = "COM-000002",
            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
            Quantite = 2,
            Remise = 0.15m,
            ProduitId = 4,
        });
        // Commande
        context.MouvementStock.Add(new MouvementStock
        {
            NumeroMouvement = "COM-000002",
            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
            Quantite = 1,
            Remise = 0.2m,
            ProduitId = 8,
        });
        // Commande
        context.MouvementStock.Add(new MouvementStock
        {
            NumeroMouvement = "COM-000002",
            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
            Quantite = 2,
            Remise = 0,
            ProduitId = 2,
        });
        // Vente
        context.MouvementStock.Add(new MouvementStock
        {
            NumeroMouvement = "VEN-000001",
            Date = DateTime.Parse("2024 - 01 - 28T12:20:00.000Z"),
            Quantite = 3,
            Remise = 0.5m,
            ProduitId = 10,
        });
        // Vente
        context.MouvementStock.Add(new MouvementStock
        {
            NumeroMouvement = "VEN-000001",
            Date = DateTime.Parse("2024 - 01 - 28T12:20:00.000Z"),
            Quantite = 5,
            Remise = 0,
            ProduitId = 16,
        });
        #endregion Mouvements de Stock
        context.SaveChanges();

        #region Récupération Mouvements de Stock
        // Commande
        var MouvementStock1 = context.MouvementStock
            .Where(ms => ms.Id == 1)
            .FirstOrDefault();
        // Commande
        var MouvementStock2 = context.MouvementStock
            .Where(ms => ms.Id == 2)
            .FirstOrDefault();
        // Commande
        var MouvementStock3 = context.MouvementStock
            .Where(ms => ms.Id == 3)
            .FirstOrDefault();
        // Vente
        var MouvementStock4 = context.MouvementStock
            .Where(ms => ms.Id == 4)
            .FirstOrDefault();
        // Vente
        var MouvementStock5 = context.MouvementStock
            .Where(ms => ms.Id == 5)
            .FirstOrDefault();
        #endregion Récupération Mouvements de Stock

        #region Commandes
        context.Commande.Add(new Commande
        {
            NumeroMouvement = "COM-000002",
            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
            Remise = 0,
            FournisseurId = 3,
            ListeMouvementStock = new[] { MouvementStock1!, MouvementStock2!, MouvementStock3! }
        });
        #endregion Commandes
        context.SaveChanges();

        #region Ventes
        context.Vente.Add(new Vente
        {
            NumeroMouvement = "VEN-000001",
            Date = DateTime.Parse("2024 - 01 - 28T12:20:00.000Z"),
            Remise = 0.33m,
            Lieu = 0,
            ClientId = 3,
            ListeMouvementStock = new[] { MouvementStock4!, MouvementStock5! },
        });
        #endregion Ventes
        context.SaveChanges();

        #region Corrections de stock
        context.CorrectionStock.Add(new CorrectionStock
        {
            NumeroMouvement = CreationCode("COR"),
            Date = DateTime.Now,
            Quantite = -1,
            ProduitId = 12,
            Nature = "Casse de bouteille"
        });
        context.CorrectionStock.Add(new CorrectionStock
        {
            NumeroMouvement = CreationCode("COR"),
            Date = DateTime.Now,
            Quantite = 3,
            ProduitId = 4,
            Nature = "Bouteilles toujours en stock car pas ajoutées dans la commande COM0005"
        });
        context.CorrectionStock.Add(new CorrectionStock
        {
            NumeroMouvement = CreationCode("COR"),
            Date = DateTime.Now,
            Quantite = 15,
            ProduitId = 7,
            Nature = "Don du fournisseur Tariquet à Noël 2023"
        });
        #endregion Corrections de stock
        context.SaveChanges();

    }
}
