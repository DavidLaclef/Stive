//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Models.Context;
//using Models.Dao;

//namespace API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class SeedsController : ControllerBase
//{
//    private readonly StiveContext _context;
//    private readonly UserManager<User> _userManager;
//    private readonly RoleManager<IdentityRole> _roleManager;

//    public SeedsController(StiveContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
//    {
//        _context = context;
//        _userManager = userManager;
//        _roleManager = roleManager;
//    }

//    // POST: api/Seeds/CreerRoles
//    [HttpPost]
//    [Route("CreerRoles")]
//    public async Task<ActionResult<bool>> PostCreerRoles()
//    {
//        if (!(await _roleManager.RoleExistsAsync("Administrateur")))
//        {
//            await _roleManager.CreateAsync(new IdentityRole("Administrateur"));
//        }
//        if (!(await _roleManager.RoleExistsAsync("Utilisateur")))
//        {
//            await _roleManager.CreateAsync(new IdentityRole("Utilisateur"));
//        }
//        return true;
//    }

//    // POST: api/Seeds/CreerUtilisateurs
//    [HttpPost]
//    [Route("CreerUtilisateurs")]
//    public async Task<ActionResult<bool>> PostCreerUtilisateurs()
//    {
//        //Création d'un utilisateur admin
//        if (!_userManager.Users.Where(u => u.UserName == "admin").Any())
//        {
//            var user = new User();
//            user.UserName = "admin";
//            user.Email = "admin@stive.fr";
//            string userPWD = "Admin1.";

//            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

//            //ajout du role Admin    
//            if (chkUser.Succeeded)
//            {
//                var result = await _userManager.AddToRoleAsync(user, "Administrateur");
//            }
//        }

//        //Création d'un utilisateur user
//        if (!_userManager.Users.Where(u => u.UserName == "david").Any())
//        {
//            var user = new User();
//            user.UserName = "david";
//            user.Email = "david@stive.fr";
//            string userPWD = "David1.";

//            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

//            //ajout du role Admin    Administrateur
//            if (chkUser.Succeeded)
//            {
//                var result = await _userManager.AddToRoleAsync(user, "Utilisateur");
//            }
//        }
//        return true;
//    }

//    public static string CreationCode(string prefixe) => $"{prefixe!}-{Guid.NewGuid().ToString().ToUpper().Substring(0, 6)}";

//    // POST: api/Seeds/InitDonnees
//    [HttpPost]
//    [Route("InitDonnees")]
//    public async Task<ActionResult<bool>> PostInitDonnees()
//    {
//        /*
//         * Crée et utilise un contexte de la base de données Stive pour effectuer les opérations CRUD sur la base de données.
//         * Using garantit que les ressources associées à ce contexte sont correctement libérées à la fin de l'utilisation grâce à la construction using.
//         */

//        #region Fournisseurs
//        _context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Tariquet", AdresseMail = "zoe@tariquet.fr", NumeroTelephone = "0686541700" });
//        _context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Pellehaut", AdresseMail = "margot@pelleheaut.fr", NumeroTelephone = "0623125578" });
//        _context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Joy", AdresseMail = "bob@joy.fr", NumeroTelephone = "0648621523" });
//        _context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Vignoble Fontan", AdresseMail = "nathan@fontan.fr", NumeroTelephone = "0662351145" });
//        _context.Fournisseur.Add(new Fournisseur { CodeFournisseur = CreationCode("FOU"), Nom = "Uby", AdresseMail = "leonie@uby.fr", NumeroTelephone = "0603195813" });
//        #endregion Fournisseurs

//        #region Clients
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Belnades",
//            Prenom = "Sypha",
//            AdresseMail = "sypha.belnades@mail.fr",
//            MotDePasse = "$2y$10$e/YYleAiaKWpKv73lbZJNO8jidopZ84XoGj4BMp8lBc/W.DaRh3dC",
//            Entreprise = "Maison Belmont",
//            NumeroTelephone = "0764126200",
//            NomLivraison = "",
//            PrenomLivraison = "",
//            DateNaissance = DateTime.Parse("1995-07-25T00:00:00.000Z"),
//            AdressePostale = "12 impasse des magiciens",
//            CodePostal = "05671",
//            Ville = "Abra Cada",
//            InstructionLivraison = "",
//            EstMembreSite = true
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Belmont",
//            Prenom = "Trevor",
//            AdresseMail = "trevor.belmont@mail.fr",
//            MotDePasse = "$2y$10$J9iBZTS42hPHybGAD/eKuuv.atAnszMJjR1uAp1B37RDQUxktR36i",
//            Entreprise = "Maison Belmont",
//            NumeroTelephone = "0647221711",
//            NomLivraison = "Tepes",
//            PrenomLivraison = "Alucard",
//            DateNaissance = DateTime.Parse("1983-11-03T00:00:00.000Z"),
//            AdressePostale = "388 avenue du Château",
//            CodePostal = "77000",
//            Ville = "Lindenfeld",
//            InstructionLivraison = "",
//            EstMembreSite = false
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Roux",
//            Prenom = "Pierre",
//            AdresseMail = "pierre.roux@mail.fr",
//            MotDePasse = "$2y$10$bF61ECPXybkV8fExVWci0Ohr1qS6gDmR6o/xkwEZ9HFlRQZdERe4u",
//            Entreprise = "",
//            NumeroTelephone = "0712345678",
//            NomLivraison = "Lefevre",
//            PrenomLivraison = "Sophie",
//            DateNaissance = DateTime.Parse("1995-11-22T00:00:00.000Z"),
//            AdressePostale = "789 Rue de la Nature",
//            CodePostal = "33000",
//            Ville = "Bordeaux",
//            InstructionLivraison = "Livrer à l'arrière de la maison",
//            EstMembreSite = true
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Morel",
//            Prenom = "Eva",
//            AdresseMail = "eva.morel@mail.fr",
//            MotDePasse = "$2y$10$A1a8z2xRd3KDCR8TJkCg3uT1yFrG5Eos6e9e25MSBmSwsgco0A5ZG",
//            Entreprise = "École de Musique",
//            NumeroTelephone = "0685123456",
//            NomLivraison = "Martin",
//            PrenomLivraison = "Antoine",
//            DateNaissance = DateTime.Parse("1987-04-30T00:00:00.000Z"),
//            AdressePostale = "456 Avenue des Harmonies",
//            CodePostal = "69002",
//            Ville = "Lyon",
//            InstructionLivraison = "Remettre le colis au gardien",
//            EstMembreSite = false
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Fournier",
//            Prenom = "Sophie",
//            AdresseMail = "sophie.fournier@mail.fr",
//            MotDePasse = "$2y$10$9t8q09o6OlG5XtvKd2sR9Or7Mvm54TNYK4zhT78H7Z7F58IAYn6nC",
//            Entreprise = "Mode Chic",
//            NumeroTelephone = "0712345678",
//            NomLivraison = "",
//            PrenomLivraison = "",
//            DateNaissance = DateTime.Parse("1980-06-28T00:00:00.000Z"),
//            AdressePostale = "567 Rue de la Mode",
//            CodePostal = "33000",
//            Ville = "Bordeaux",
//            InstructionLivraison = "",
//            EstMembreSite = true
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Moreau",
//            Prenom = "Lucas",
//            AdresseMail = "lucas.moreau@mail.fr",
//            MotDePasse = "$2y$10$Y1o3d8etTnzlT8oqf44wrO8j0efnC9eBp5XScMPN02mGPTo0fc9LS",
//            Entreprise = "",
//            NumeroTelephone = "0765987452",
//            NomLivraison = "Dubois",
//            PrenomLivraison = "Emma",
//            DateNaissance = DateTime.Parse("1993-12-05T00:00:00.000Z"),
//            AdressePostale = "234 Avenue de la Paix",
//            CodePostal = "69001",
//            Ville = "Lyon",
//            InstructionLivraison = "Livrer à la porte arrière",
//            EstMembreSite = false
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Girard",
//            Prenom = "Julie",
//            AdresseMail = "julie.girard@mail.fr",
//            MotDePasse = "$2y$10$QxQy6Db4Z2NEp9oMPHxUa.r8wXhndWT2vG6OSJ/8p/9/MXQYNU1hq",
//            Entreprise = "Studio Créatif",
//            NumeroTelephone = "0687452369",
//            NomLivraison = "Lefevre",
//            PrenomLivraison = "Thomas",
//            DateNaissance = DateTime.Parse("1989-09-18T00:00:00.000Z"),
//            AdressePostale = "987 Rue de l'Art",
//            CodePostal = "75012",
//            Ville = "Paris",
//            InstructionLivraison = "Déposer le colis à la conciergerie",
//            EstMembreSite = false
//        });
//        _context.Client.Add(new Client
//        {
//            CodeClient = CreationCode("CLI"),
//            Nom = "Lefevre",
//            Prenom = "Jean",
//            AdresseMail = "jean.lefevre@mail.fr",
//            MotDePasse = "$2y$10$Aq6o3G06eM5CVixb0oKoMecUpnM7Moxk1QELJfT5GUPkKmHLx.hSS",
//            Entreprise = "",
//            NumeroTelephone = "0655987452",
//            NomLivraison = "Durand",
//            PrenomLivraison = "Marjorie",
//            DateNaissance = DateTime.Parse("1985-08-22T00:00:00.000Z"),
//            AdressePostale = "456 Rue de la Libération",
//            CodePostal = "69000",
//            Ville = "Lyon",
//            InstructionLivraison = "",
//            EstMembreSite = false
//        });
//        #endregion Clients

//        #region Utilisateurs
//        _context.Utilisateur.Add(new Utilisateur
//        {
//            CodeUtilisateur = CreationCode("UTI"),
//            Nom = "Cleveland",
//            Prenom = "Glenda",
//            AdresseMail = "glenda.cleveland@mail.fr",
//            MotDePasse = "$2y$10$GZSwP/4UG7RDCazJ0noJxueOnaDXZgF1I.jVbSDtF3R6a1olLL1uS",
//            EstGerant = false
//        });
//        _context.Utilisateur.Add(new Utilisateur
//        {
//            CodeUtilisateur = CreationCode("UTI"),
//            Nom = "Imm",
//            Prenom = "Leonor",
//            AdresseMail = "leonor.imm@mail.fr",
//            MotDePasse = "$2y$10$e/YYleAiaKWpKv73lbZJNO8jidopZ84XoGj4BMp8lBc/W.DaRh3dC",
//            EstGerant = false
//        });
//        _context.Utilisateur.Add(new Utilisateur
//        {
//            CodeUtilisateur = CreationCode("UTI"),
//            Nom = "Lopez",
//            Prenom = "Carlos",
//            AdresseMail = "carlos.lopez@mail.fr",
//            MotDePasse = "$2y$10$RIm04.gFmjyYoyTnFoy2Meq0Tt5aKJkwPjK6czX/otEL4XYdswCEW",
//            EstGerant = false

//        });
//        _context.Utilisateur.Add(new Utilisateur
//        {
//            CodeUtilisateur = CreationCode("UTI"),
//            Nom = "Mastfor",
//            Prenom = "Isaac",
//            AdresseMail = "isaac.mastfor@mail.fr",
//            MotDePasse = "$2y$10$0W4m.ExniqoAAeszAGyWF.g7oXxuHVMmj04ItmeDuNXAbuLyXnfNe",
//            EstGerant = true
//        });
//        #endregion Utilisateurs

//        #region Châteaux
//        _context.Chateau.Add(new Chateau { Nom = "Margaux" });
//        _context.Chateau.Add(new Chateau { Nom = "Lafite Rothschild" });
//        _context.Chateau.Add(new Chateau { Nom = "Latour" });
//        _context.Chateau.Add(new Chateau { Nom = "Haut-Biron" });
//        _context.Chateau.Add(new Chateau { Nom = "Yquem" });
//        _context.Chateau.Add(new Chateau { Nom = "Montrose" });
//        _context.Chateau.Add(new Chateau { Nom = "Palmer" });
//        _context.Chateau.Add(new Chateau { Nom = "Lynch-Bages" });
//        #endregion Châteaux

//        #region Familles
//        _context.Famille.Add(new Famille { Nom = "Rouge" });
//        _context.Famille.Add(new Famille { Nom = "Rosé" });
//        _context.Famille.Add(new Famille { Nom = "Blanc" });
//        _context.Famille.Add(new Famille { Nom = "Pétillant" });
//        _context.Famille.Add(new Famille { Nom = "Digestif" });
//        await _context.SaveChangesAsync();

//        var Famille1 = _context.Famille
//            .Where(f => f.Id == 1)
//            .FirstOrDefault();

//        var Famille2 = _context.Famille
//            .Where(f => f.Id == 2)
//            .FirstOrDefault();

//        var Famille3 = _context.Famille
//            .Where(f => f.Id == 3)
//            .FirstOrDefault();

//        var Famille4 = _context.Famille
//            .Where(f => f.Id == 4)
//            .FirstOrDefault();

//        var Famille5 = _context.Famille
//            .Where(f => f.Id == 5)
//            .FirstOrDefault();
//        #endregion Familles
//        await _context.SaveChangesAsync();

//        #region Produits
//        _context.Produit.Add(new Produit
//        {
//            //Familles = new[] { Famille1!, Famille4! },
//            ChateauId = 1,
//            Nom = "Château Montrose",
//            Millesime = new DateTime(2010, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 300,
//            PrixCartonVente = 1650,
//            PrixCartonCommande = 1200,
//            Description = "Offre puissance, complexité, fruits noirs et tanins fins.",
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille2!, Famille4! },
//            ChateauId = 6,
//            Nom = "La Dame de Montrose",
//            Millesime = new DateTime(2015, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 50,
//            PrixCartonVente = 270,
//            PrixCartonCommande = 130,
//            Description = "Apporte fraîcheur, équilibre, fruits rouges et texture soyeuse."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille4!, Famille5! },
//            ChateauId = 7,
//            Nom = "Château Palmer",
//            Millesime = new DateTime(2016, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 300,
//            PrixCartonVente = 1550,
//            PrixCartonCommande = 1300,
//            Description = "Élégance, complexité florale, tanins veloutés."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille3!, Famille5! },
//            ChateauId = 7,
//            Nom = "Alter Ego de Palmer",
//            Millesime = new DateTime(2018, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 70,
//            PrixCartonVente = 400,
//            PrixCartonCommande = 360,
//            Description = "Fraîcheur, fruité, équilibre, facilité de dégustation."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille1!, Famille4! },
//            ChateauId = 8,
//            Nom = "Château Lynch-Bages",
//            Millesime = new DateTime(2010, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 200,
//            PrixCartonVente = 1100,
//            PrixCartonCommande = 850,
//            Description = "Structuré, fruits mûrs, épices, finale persistante."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille4!, Famille5! },
//            ChateauId = 8,
//            Nom = "Echo de Lynch-Bages",
//            Millesime = new DateTime(2016, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 40,
//            PrixCartonVente = 220,
//            PrixCartonCommande = 180,
//            Description = "Souplesse, fruité, tanins souples, fraîcheur agréable."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille2!, Famille4! },
//            ChateauId = 1,
//            Nom = "Château Margaux",
//            Millesime = new DateTime(2016, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 900,
//            PrixCartonVente = 6000,
//            PrixCartonCommande = 4800,
//            Description = "Raffinement, complexité, fruits noirs, tanins soyeux."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille3!, Famille5! },
//            ChateauId = 1,
//            Nom = "Pavillon Blanc de Château Margaux",
//            Millesime = new DateTime(2018, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 500,
//            PrixCartonVente = 2850,
//            PrixCartonCommande = 2500,
//            Description = "Fraîcheur, citron, minéralité, grande élégance."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille5! },
//            ChateauId = 1,
//            Nom = "Margaux du Château Margaux",
//            Millesime = new DateTime(2015, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 250,
//            PrixCartonVente = 1480,
//            PrixCartonCommande = 1210,
//            Description = "Harmonie, fruits rouges, épices douces, longueur en bouche."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille3!, Famille5! },
//            ChateauId = 2,
//            Nom = "Château Lafite Rothschild",
//            Millesime = new DateTime(2010, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 1500,
//            PrixCartonVente = 8700,
//            PrixCartonCommande = 7350,
//            Description = "Puissance, concentration, fruits noirs, tanins fins, longueur."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille4! },
//            ChateauId = 2,
//            Nom = "Carruades de Lafite",
//            Millesime = new DateTime(2015, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 300,
//            PrixCartonVente = 1720,
//            PrixCartonCommande = 1500,
//            Description = "Fraîcheur, fruits rouges, élégance, tanins souples."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille3! },
//            ChateauId = 3,
//            Nom = "Château Latour",
//            Millesime = new DateTime(2005, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 1200,
//            PrixCartonVente = 6980,
//            PrixCartonCommande = 5860,
//            Description = "Concentration, complexité, fruits noirs, tanins puissants, longue garde."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille2! },
//            ChateauId = 3,
//            Nom = "Les Forts de Latour",
//            Millesime = new DateTime(2012, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 300,
//            PrixCartonVente = 1770,
//            PrixCartonCommande = 1590,
//            Description = "Équilibre, fruits rouges, tanins soyeux, élégance."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille2!, Famille5! },
//            ChateauId = 4,
//            Nom = "Château Haut-Brion",
//            Millesime = new DateTime(2010, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 900,
//            PrixCartonVente = 6100,
//            PrixCartonCommande = 4900,
//            Description = "Profondeur, complexité, fruits noirs, notes fumées, tanins veloutés."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille1! },
//            ChateauId = 4,
//            Nom = "Château Haut-Brion Blanc",
//            Millesime = new DateTime(2014, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 900,
//            PrixCartonVente = 6100,
//            PrixCartonCommande = 4900,
//            Description = "Richesse, agrumes, minéralité, finale persistante."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille5! },
//            ChateauId = 5,
//            Nom = "Château d'Yquem",
//            Millesime = new DateTime(2015, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 400,
//            PrixCartonVente = 2370,
//            PrixCartonCommande = 2000,
//            Description = "Intensité, miel, fruits exotiques, parfait équilibre."
//        });
//        _context.Produit.Add(new Produit
//        {
//            Familles = new[] { Famille3! },
//            ChateauId = 5,
//            Nom = "Y",
//            Millesime = new DateTime(2018, 1, 1),
//            PhotoProduit = "chemin/vers/fichier/photo.png",
//            PrixUnitaireVente = 150,
//            PrixCartonVente = 880,
//            PrixCartonCommande = 750,
//            Description = "Fraîcheur, fruits blancs, élégance, finale persistante."
//        });
//        #endregion Produits
//        await _context.SaveChangesAsync();

//        #region Mouvements de Stock
//        // Commande
//        _context.MouvementStock.Add(new MouvementStock
//        {
//            Id = 1,
//            NumeroMouvement = "COM-000002",
//            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
//            Quantite = 2,
//            Remise = 0.15m,
//            ProduitId = 4,
//        });
//        // Commande
//        _context.MouvementStock.Add(new MouvementStock
//        {
//            Id = 2,
//            NumeroMouvement = "COM-000002",
//            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
//            Quantite = 1,
//            Remise = 0.2m,
//            ProduitId = 8,
//        });
//        // Commande
//        _context.MouvementStock.Add(new MouvementStock
//        {
//            Id = 3,
//            NumeroMouvement = "COM-000002",
//            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
//            Quantite = 2,
//            Remise = 0,
//            ProduitId = 2,
//        });
//        // Vente
//        _context.MouvementStock.Add(new MouvementStock
//        {
//            Id = 4,
//            NumeroMouvement = "VEN-000001",
//            Date = DateTime.Parse("2024 - 01 - 28T12:20:00.000Z"),
//            Quantite = 3,
//            Remise = 0.5m,
//            ProduitId = 10,
//        });
//        // Vente
//        _context.MouvementStock.Add(new MouvementStock
//        {
//            Id = 5,
//            NumeroMouvement = "VEN-000001",
//            Date = DateTime.Parse("2024 - 01 - 28T12:20:00.000Z"),
//            Quantite = 5,
//            Remise = 0,
//            ProduitId = 16,
//        });
//        #endregion Mouvements de Stock
//        await _context.SaveChangesAsync();

//        #region Récupération Mouvements de Stock
//        // Commande
//        var MouvementStock1 = _context.MouvementStock
//            .Where(ms => ms.Id == 1)
//            .FirstOrDefault();
//        // Commande
//        var MouvementStock2 = _context.MouvementStock
//            .Where(ms => ms.Id == 2)
//            .FirstOrDefault();
//        // Commande
//        var MouvementStock3 = _context.MouvementStock
//            .Where(ms => ms.Id == 3)
//            .FirstOrDefault();
//        // Vente
//        var MouvementStock4 = _context.MouvementStock
//            .Where(ms => ms.Id == 4)
//            .FirstOrDefault();
//        // Vente
//        var MouvementStock5 = _context.MouvementStock
//            .Where(ms => ms.Id == 5)
//            .FirstOrDefault();
//        #endregion Récupération Mouvements de Stock

//        #region Commandes
//        _context.Commande.Add(new Commande
//        {
//            NumeroMouvement = "COM-000002",
//            Date = DateTime.Parse("2024 - 01 - 20T18:45:00.000Z"),
//            Remise = 0,
//            FournisseurId = 3,
//            ListeMouvementStock = new[] { MouvementStock1!, MouvementStock2!, MouvementStock3! }
//        });
//        #endregion Commandes
//        await _context.SaveChangesAsync();

//        #region Ventes
//        _context.Vente.Add(new Vente
//        {
//            NumeroMouvement = "VEN-000001",
//            Date = DateTime.Parse("2024 - 01 - 28T12:20:00.000Z"),
//            Remise = 0.33m,
//            Lieu = 0,
//            ClientId = 3,
//            ListeMouvementStock = new[] { MouvementStock4!, MouvementStock5! },
//        });
//        #endregion Ventes
//        await _context.SaveChangesAsync();

//        #region Corrections de stock
//        _context.CorrectionStock.Add(new CorrectionStock
//        {
//            NumeroMouvement = CreationCode("COR"),
//            Date = DateTime.Now,
//            Quantite = -1,
//            ProduitId = 12,
//            Nature = "Casse de bouteille"
//        });
//        _context.CorrectionStock.Add(new CorrectionStock
//        {
//            NumeroMouvement = CreationCode("COR"),
//            Date = DateTime.Now,
//            Quantite = 3,
//            ProduitId = 4,
//            Nature = "Bouteilles toujours en stock car pas ajoutées dans la commande COM0005"
//        });
//        _context.CorrectionStock.Add(new CorrectionStock
//        {
//            NumeroMouvement = CreationCode("COR"),
//            Date = DateTime.Now,
//            Quantite = 15,
//            ProduitId = 7,
//            Nature = "Don du fournisseur Tariquet à Noël 2023"
//        });
//        #endregion Corrections de stock
//        await _context.SaveChangesAsync();

//        return true;
//    }
//}
