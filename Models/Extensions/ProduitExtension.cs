using Models.Dao;
using Models.Dto;
using System.Text;

namespace Models.Extensions
{
    public static class ProduitExtension
    {
        public static ProduitDto ToDto(this Produit produit)
        {
            var produitDto = new ProduitDto
            {
                Id = produit.Id,
                Nom = produit.Nom,
                PhotoProduit = produit.PhotoProduit,
                Millesime = produit.Millesime.ToString("yyyy"),
                Description = produit.Description,
                Quantite = produit.Quantite,
                QuantiteReapprovisionnement = produit.QuantiteReapprovisionnement,
                SeuilReapprovisionnement = produit.SeuilReapprovisionnement,
                Statut = produit.Statut,
                PrixUnitaireVente = produit.PrixUnitaireVente,
                PrixCartonVente = produit.PrixCartonVente,
                PrixCartonCommande = produit.PrixCartonCommande,
                Chateau = produit.Chateau?.ToLightDto(),
                HistoriquesPrix = produit.HistoriquesPrix,
                Familles = [],
                FamillesConcatenees = string.Empty,
                MouvementsStock = []

            };

            // Créer une chaîne pour stocker les noms des familles concaténés
            StringBuilder famillesConcat = new();

            if (produit.Familles != null)
            {
                foreach (var famille in produit.Familles)
                {
                    FamilleLightDto familleLightDto = famille.ToLightDto();
                    produitDto.Familles?.Add(familleLightDto);

                    // Ajouter le nom de la famille à la chaîne concaténée
                    famillesConcat.Append(famille.Nom);
                    famillesConcat.Append(' '); // Ajouter un espace entre les noms des familles
                }
            }

            // Assigner la chaîne de familles concaténées à l'attribut correspondant dans le DTO
            produitDto.FamillesConcatenees = famillesConcat.ToString().Trim(); // Retirer les espaces inutiles en fin de chaîne

            if (produit.MouvementsStock != null)
            {
                foreach (var mouvement in produit.MouvementsStock)
                {
                    MouvementStockLightDto mouvementStockLightDto = mouvement.ToLightDto();
                    produitDto.MouvementsStock?.Add(mouvementStockLightDto);
                }
            }

            return produitDto;
        }

        public static ProduitMediumDto ToMediumDto(this Produit produit)
        {
            var produitMediumDto = new ProduitMediumDto
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Quantite = produit.Quantite,
                Chateau = produit.Chateau?.ToLightDto(),
                Familles = [],
                FamillesConcatenees = string.Empty
            };

            // Créer une chaîne pour stocker les noms des familles concaténés
            StringBuilder famillesConcat = new();

            if (produit.Familles != null)
            {
                foreach (var famille in produit.Familles)
                {
                    FamilleLightDto familleLightDto = famille.ToLightDto();
                    produitMediumDto.Familles?.Add(familleLightDto);

                    // Ajouter le nom de la famille à la chaîne concaténée
                    famillesConcat.Append(famille.Nom);
                    famillesConcat.Append(' '); // Ajouter un espace entre les noms des familles
                }
            }

            // Assigner la chaîne de familles concaténées à l'attribut correspondant dans le DTO
            produitMediumDto.FamillesConcatenees = famillesConcat.ToString().Trim(); // Retirer les espaces inutiles en fin de chaîne

            return produitMediumDto;
        }

        public static ProduitLightDto ToLightDto(this Produit produit)
        {
            var produitLightDto = new ProduitLightDto
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Millesime = produit.Millesime.ToString("yyyy"),
                Description = produit.Description,
                Quantite = produit.Quantite,
                QuantiteReapprovisionnement = produit.QuantiteReapprovisionnement,
                SeuilReapprovisionnement = produit.SeuilReapprovisionnement,
                Statut = produit.Statut,
                PrixUnitaireVente = produit.PrixUnitaireVente,
                PrixCartonVente = produit.PrixCartonVente,
                PrixCartonCommande = produit.PrixCartonCommande,
                Chateau = produit.Chateau?.ToLightDto(),
                Familles = [],
                FamillesConcatenees = string.Empty
            };

            // Créer une chaîne pour stocker les noms des familles concaténés
            StringBuilder famillesConcat = new();

            if (produit.Familles != null)
            {
                foreach (var famille in produit.Familles)
                {
                    FamilleLightDto familleLightDto = famille.ToLightDto();
                    produitLightDto.Familles?.Add(familleLightDto);

                    // Ajouter le nom de la famille à la chaîne concaténée
                    famillesConcat.Append(famille.Nom);
                    famillesConcat.Append(' '); // Ajouter un espace entre les noms des familles
                }
            }

            // Assigner la chaîne de familles concaténées à l'attribut correspondant dans le DTO
            produitLightDto.FamillesConcatenees = famillesConcat.ToString().Trim(); // Retirer les espaces inutiles en fin de chaîne

            return produitLightDto;
        }

        public static ProduitLittleDto ToLittleDto(this Produit produit)
        {
            return new ProduitLittleDto
            {
                Id = produit.Id,
                Nom = produit.Nom
            };
        }
    }
}
