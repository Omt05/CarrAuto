using CarrAuto.Models;
using Microsoft.EntityFrameworkCore;

namespace CarrAuto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<CategorieProduit> CategoriesProduits { get; set; }
        public DbSet<VehiculeOccasion> VehiculesOccasion { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CategorieService> CategoriesServices { get; set; }
        public DbSet<DemandeDevis> DemandesDevis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure relationships
            modelBuilder.Entity<Produit>()
                .HasOne(p => p.CategorieProduit)
                .WithMany(c => c.Produits)
                .HasForeignKey(p => p.CategorieProduitId);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.CategorieService)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CategorieServiceId);

            // Seed data for CategorieProduit
            modelBuilder.Entity<CategorieProduit>().HasData(
                new CategorieProduit { Id = 1, Nom = "Essuie-glaces", Description = "Tous types d'essuie-glaces pour votre véhicule" },
                new CategorieProduit { Id = 2, Nom = "Ampoules", Description = "Ampoules pour phares et éclairage intérieur" },
                new CategorieProduit { Id = 3, Nom = "Huiles moteur", Description = "Huiles de qualité pour tous types de moteurs" },
                new CategorieProduit { Id = 4, Nom = "Produits lave-glace", Description = "Produits de nettoyage pour vitres et pare-brise" },
                new CategorieProduit { Id = 5, Nom = "Filtres", Description = "Filtres à huile, à air, à carburant et d'habitacle" },
                new CategorieProduit { Id = 6, Nom = "Batteries", Description = "Batteries pour tous types de véhicules" },
                new CategorieProduit { Id = 7, Nom = "Outillage", Description = "Outils pour l'entretien de votre véhicule" }
            );

            // Seed data for CategorieService
            modelBuilder.Entity<CategorieService>().HasData(
                new CategorieService { Id = 1, Nom = "Réparation mécanique", Description = "Services de réparation mécanique pour votre véhicule" },
                new CategorieService { Id = 2, Nom = "Entretien régulier", Description = "Services d'entretien courant pour votre véhicule" },
                new CategorieService { Id = 3, Nom = "Diagnostic électronique", Description = "Services de diagnostic des problèmes électroniques" },
                new CategorieService { Id = 4, Nom = "Montage de pneus", Description = "Services de montage et équilibrage de pneus" },
                new CategorieService { Id = 5, Nom = "Climatisation", Description = "Services liés à la climatisation de votre véhicule" }
            );

            // Sample products
            modelBuilder.Entity<Produit>().HasData(
                new Produit { Id = 1, Nom = "Huile Syntec 5W-30", Description = "Huile synthétique haute performance pour moteurs essence", Prix = 39.99m, CategorieProduitId = 3, QuantiteStock = 50, EstDisponible = true, ImageUrl = "/images/products/huile-syntec.jpg", EnStock = true, EstPopulaire = true },
                new Produit { Id = 2, Nom = "Jeu d'essuie-glaces universel", Description = "Essuie-glaces de qualité supérieure adaptables à la plupart des véhicules", Prix = 24.99m, CategorieProduitId = 1, QuantiteStock = 30, EstDisponible = true, ImageUrl = "/images/products/essuie-glaces.jpg", EnStock = true },
                new Produit { Id = 3, Nom = "Filtre à air K&N", Description = "Filtre à air haute performance lavable et réutilisable", Prix = 49.99m, CategorieProduitId = 5, QuantiteStock = 15, EstDisponible = true, ImageUrl = "/images/products/filtre-air.jpg", EnStock = true, EstPopulaire = true },
                new Produit { Id = 4, Nom = "Batterie Exide 12V", Description = "Batterie fiable pour véhicules de tourisme standard", Prix = 89.99m, CategorieProduitId = 6, QuantiteStock = 10, EstDisponible = true, ImageUrl = "/images/products/batterie.jpg", EnStock = true }
            );

            // Sample services
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Nom = "Vidange complète", Description = "Vidange d'huile avec remplacement du filtre à huile", PrixEstimatif = 69.99m, CategorieServiceId = 2, ImageUrl = "/images/services/oil-change.jpg" },
                new Service { Id = 2, Nom = "Montage et équilibrage de pneus", Description = "Montage, équilibrage et permutation de vos pneus", PrixEstimatif = 49.99m, CategorieServiceId = 4, ImageUrl = "/images/services/tire-mounting.jpg" },
                new Service { Id = 3, Nom = "Diagnostic électronique complet", Description = "Analyse complète des systèmes électroniques de votre véhicule", PrixEstimatif = 59.99m, CategorieServiceId = 3, ImageUrl = "/images/services/diagnostic.jpg" },
                new Service { Id = 4, Nom = "Recharge de climatisation", Description = "Contrôle et recharge du circuit de climatisation", PrixEstimatif = 79.99m, CategorieServiceId = 5, ImageUrl = "/images/services/ac-service.jpg" }
            );

            // Sample used vehicles
            modelBuilder.Entity<VehiculeOccasion>().HasData(
                new VehiculeOccasion { 
                    Id = 1, 
                    Marque = "Toyota", 
                    Modele = "Corolla", 
                    Annee = 2018, 
                    Kilometrage = 65000, 
                    Prix = 14999.99m, 
                    Description = "Toyota Corolla en excellent état, entretien régulier, un seul propriétaire", 
                    Couleur = "Bleu", 
                    TypeCarburant = "Essence", 
                    Transmission = "Automatique", 
                    EstDisponible = true, 
                    DateMiseEnVente = new DateTime(2023, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ImageUrl = "/images/vehicles/toyota-corolla.jpg"
                },
                new VehiculeOccasion { 
                    Id = 2, 
                    Marque = "Honda", 
                    Modele = "Civic", 
                    Annee = 2019, 
                    Kilometrage = 48000, 
                    Prix = 16500.00m, 
                    Description = "Honda Civic en parfait état, jamais accidentée, tout l'historique d'entretien disponible", 
                    Couleur = "Rouge", 
                    TypeCarburant = "Essence", 
                    Transmission = "Manuelle", 
                    EstDisponible = true, 
                    DateMiseEnVente = new DateTime(2023, 3, 10, 0, 0, 0, DateTimeKind.Utc),
                    ImageUrl = "/images/vehicles/honda-civic.jpg"
                },
                new VehiculeOccasion { 
                    Id = 3, 
                    Marque = "Ford", 
                    Modele = "Escape", 
                    Annee = 2017, 
                    Kilometrage = 78000, 
                    Prix = 13750.00m, 
                    Description = "SUV Ford Escape idéal pour la famille, bien entretenu, pneus neufs", 
                    Couleur = "Gris", 
                    TypeCarburant = "Essence", 
                    Transmission = "Automatique", 
                    EstDisponible = true, 
                    DateMiseEnVente = new DateTime(2023, 2, 5, 0, 0, 0, DateTimeKind.Utc),
                    ImageUrl = "/images/vehicles/ford-escape.jpg"
                }
            );
        }
    }
}
