using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarrAuto.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesProduits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesProduits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandesDevis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MarqueVehicule = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModeleVehicule = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnneeVehicule = table.Column<int>(type: "int", nullable: false),
                    DescriptionTravaux = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontantDevis = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommentairesInternes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesDevis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculesOccasion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marque = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Kilometrage = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Couleur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeCarburant = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImagesSupplementaires = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puissance = table.Column<int>(type: "int", nullable: true),
                    OptionsPrincipales = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EstDisponible = table.Column<bool>(type: "bit", nullable: false),
                    DateMiseEnVente = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculesOccasion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixPromotion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EnPromotion = table.Column<bool>(type: "bit", nullable: false),
                    EstPopulaire = table.Column<bool>(type: "bit", nullable: false),
                    EnStock = table.Column<bool>(type: "bit", nullable: false),
                    QuantiteStock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategorieProduitId = table.Column<int>(type: "int", nullable: false),
                    EstDisponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_CategoriesProduits_CategorieProduitId",
                        column: x => x.CategorieProduitId,
                        principalTable: "CategoriesProduits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PrixEstimatif = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DetailsSupplementaires = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EstPopulaire = table.Column<bool>(type: "bit", nullable: false),
                    CategorieServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_CategoriesServices_CategorieServiceId",
                        column: x => x.CategorieServiceId,
                        principalTable: "CategoriesServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriesProduits",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { 1, "Tous types d'essuie-glaces pour votre véhicule", "Essuie-glaces" },
                    { 2, "Ampoules pour phares et éclairage intérieur", "Ampoules" },
                    { 3, "Huiles de qualité pour tous types de moteurs", "Huiles moteur" },
                    { 4, "Produits de nettoyage pour vitres et pare-brise", "Produits lave-glace" },
                    { 5, "Filtres à huile, à air, à carburant et d'habitacle", "Filtres" },
                    { 6, "Batteries pour tous types de véhicules", "Batteries" },
                    { 7, "Outils pour l'entretien de votre véhicule", "Outillage" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesServices",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { 1, "Services de réparation mécanique pour votre véhicule", "Réparation mécanique" },
                    { 2, "Services d'entretien courant pour votre véhicule", "Entretien régulier" },
                    { 3, "Services de diagnostic des problèmes électroniques", "Diagnostic électronique" },
                    { 4, "Services de montage et équilibrage de pneus", "Montage de pneus" },
                    { 5, "Services liés à la climatisation de votre véhicule", "Climatisation" }
                });

            migrationBuilder.InsertData(
                table: "VehiculesOccasion",
                columns: new[] { "Id", "Annee", "Couleur", "DateMiseEnVente", "Description", "EstDisponible", "ImageUrl", "ImagesSupplementaires", "Kilometrage", "Marque", "Modele", "OptionsPrincipales", "Prix", "Puissance", "Transmission", "TypeCarburant" },
                values: new object[,]
                {
                    { 1, 2018, "Bleu", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Toyota Corolla en excellent état, entretien régulier, un seul propriétaire", true, "/images/vehicles/toyota-corolla.jpg", null, 65000, "Toyota", "Corolla", null, 14999.99m, null, "Automatique", "Essence" },
                    { 2, 2019, "Rouge", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Honda Civic en parfait état, jamais accidentée, tout l'historique d'entretien disponible", true, "/images/vehicles/honda-civic.jpg", null, 48000, "Honda", "Civic", null, 16500.00m, null, "Manuelle", "Essence" },
                    { 3, 2017, "Gris", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "SUV Ford Escape idéal pour la famille, bien entretenu, pneus neufs", true, "/images/vehicles/ford-escape.jpg", null, 78000, "Ford", "Escape", null, 13750.00m, null, "Automatique", "Essence" }
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "CategorieProduitId", "Description", "EnPromotion", "EnStock", "EstDisponible", "EstPopulaire", "ImageUrl", "Nom", "Prix", "PrixPromotion", "QuantiteStock" },
                values: new object[,]
                {
                    { 1, 3, "Huile synthétique haute performance pour moteurs essence", false, true, true, true, "/images/products/huile-syntec.jpg", "Huile Syntec 5W-30", 39.99m, null, 50 },
                    { 2, 1, "Essuie-glaces de qualité supérieure adaptables à la plupart des véhicules", false, true, true, false, "/images/products/essuie-glaces.jpg", "Jeu d'essuie-glaces universel", 24.99m, null, 30 },
                    { 3, 5, "Filtre à air haute performance lavable et réutilisable", false, true, true, true, "/images/products/filtre-air.jpg", "Filtre à air K&N", 49.99m, null, 15 },
                    { 4, 6, "Batterie fiable pour véhicules de tourisme standard", false, true, true, false, "/images/products/batterie.jpg", "Batterie Exide 12V", 89.99m, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CategorieServiceId", "Description", "DetailsSupplementaires", "EstPopulaire", "ImageUrl", "Nom", "PrixEstimatif" },
                values: new object[,]
                {
                    { 1, 2, "Vidange d'huile avec remplacement du filtre à huile", null, false, "/images/services/oil-change.jpg", "Vidange complète", 69.99m },
                    { 2, 4, "Montage, équilibrage et permutation de vos pneus", null, false, "/images/services/tire-mounting.jpg", "Montage et équilibrage de pneus", 49.99m },
                    { 3, 3, "Analyse complète des systèmes électroniques de votre véhicule", null, false, "/images/services/diagnostic.jpg", "Diagnostic électronique complet", 59.99m },
                    { 4, 5, "Contrôle et recharge du circuit de climatisation", null, false, "/images/services/ac-service.jpg", "Recharge de climatisation", 79.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieProduitId",
                table: "Produits",
                column: "CategorieProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategorieServiceId",
                table: "Services",
                column: "CategorieServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandesDevis");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "VehiculesOccasion");

            migrationBuilder.DropTable(
                name: "CategoriesProduits");

            migrationBuilder.DropTable(
                name: "CategoriesServices");
        }
    }
}
