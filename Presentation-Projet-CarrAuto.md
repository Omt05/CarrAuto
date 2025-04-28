# Présentation du Projet Carr'auto

## Aperçu du Projet

**Garage Carr'auto** est une application web complète développée avec ASP.NET Core 8.0 MVC pour un garage automobile familial. Cette application non-commerciale (sans e-commerce) permet aux clients de découvrir l'historique du garage, ses services, ses produits, ses véhicules d'occasion, et de demander des devis en ligne.

## Technologies Utilisées

- **Framework Backend** : ASP.NET Core 8.0 MVC
- **ORM** : Entity Framework Core 8.0.2
- **Base de données** : SQL Server (configurable, initialement SQL Express)
- **Frontend** : HTML5, CSS3, JavaScript, Bootstrap 5
- **Architecture** : Model-View-Controller (MVC)

## Structure du Projet

Le projet suit l'architecture MVC standard avec les composants suivants :

### Modèles (Models)

Les modèles représentent les entités métier et sont définis dans le dossier `Models/` :

1. **Produit.cs**
   - Représente les produits vendus par le garage
   - Propriétés clés : `Id`, `Nom`, `Description`, `Prix`, `PrixPromotion`, `EnPromotion`, `EstPopulaire`, `EnStock`, `QuantiteStock`, `ImageUrl`, `CategorieProduitId`
   - Navigation : `CategorieProduit`

2. **CategorieProduit.cs**
   - Représente les catégories de produits
   - Propriétés clés : `Id`, `Nom`, `Description`
   - Navigation : Collection de `Produits`

3. **Service.cs**
   - Représente les services offerts par le garage
   - Propriétés clés : `Id`, `Nom`, `Description`, `PrixEstimatif`, `ImageUrl`, `CategorieServiceId`, `DetailsSupplementaires`, `EstPopulaire`
   - Navigation : `CategorieService`

4. **CategorieService.cs**
   - Représente les catégories de services
   - Propriétés clés : `Id`, `Nom`, `Description`
   - Navigation : Collection de `Services`

5. **VehiculeOccasion.cs**
   - Représente les véhicules d'occasion à vendre
   - Propriétés clés : `Id`, `Marque`, `Modele`, `Annee`, `Kilometrage`, `Prix`, `Description`, `Couleur`, `TypeCarburant`, `Transmission`, `ImageUrl`, `DateMiseEnVente`, `EstDisponible`, `ImagesSupplementaires`, `Puissance`, `OptionsPrincipales`

6. **DemandeDevis.cs**
   - Représente les demandes de devis soumises par les clients
   - Propriétés clés : `Id`, `Nom`, `Prenom`, `Email`, `Telephone`, `Message`, `DateDemande`, `ServicesSelectionnes`, `VehiculeId`, `MontantDevis`, `Statut`

### Contrôleurs (Controllers)

Les contrôleurs gèrent les interactions utilisateur et sont définis dans le dossier `Controllers/` :

1. **HomeController.cs**
   - Gère les pages principales : accueil, histoire, contact
   - Méthodes principales : `Index()`, `Histoire()`, `Contact()`, `Privacy()`, `Error()`
   - Fonctionnalités spéciales : Affichage dynamique des derniers véhicules et services populaires sur la page d'accueil

2. **ProduitsController.cs**
   - Gère la gestion des produits et leur affichage
   - Méthodes CRUD : `Index()`, `Details()`, `Create()`, `Edit()`, `Delete()`
   - Fonctionnalités spéciales : Filtrage par catégorie avec `ParCategorie()`
   - Utilisation asynchrone d'Entity Framework avec `async/await`

3. **ServicesController.cs**
   - Gère la gestion des services et leur affichage
   - Méthodes CRUD : `Index()`, `Details()`, `Create()`, `Edit()`, `Delete()`
   - Fonctionnalités spéciales : Filtrage par catégorie

4. **VehiculeOccasionController.cs**
   - Gère les véhicules d'occasion et leur affichage
   - Méthodes CRUD : `Index()`, `Details()`, `Create()`, `Edit()`, `Delete()`
   - Fonctionnalités spéciales : Recherche avancée avec `Recherche()` et `ResultatsRecherche()`

5. **DevisController.cs**
   - Gère les demandes de devis en ligne
   - Méthodes principales : `Create()`, `Confirmation()`
   - Fonctionnalités spéciales : Chargement dynamique des services pour le formulaire de devis

### Vues (Views)

Les vues définissent l'interface utilisateur et sont organisées par contrôleur dans le dossier `Views/` :

1. **Layout**
   - `_Layout.cshtml` : Template principal du site
   - Intègre la navigation, l'en-tête et le pied de page
   - Supporte les sections pour les styles personnalisés (`Styles`) et les scripts (`Scripts`)

2. **Home**
   - `Index.cshtml` : Page d'accueil avec carousel, services vedettes et derniers véhicules
   - `Histoire.cshtml` : Chronologie historique du garage
   - `Contact.cshtml` : Formulaire de contact et informations
   - `Privacy.cshtml` : Politique de confidentialité

3. **Produits**
   - `Index.cshtml` : Liste des produits avec filtrage par catégorie
   - `Details.cshtml` : Détails d'un produit avec informations sur le stock et les promotions
   - `Create.cshtml`, `Edit.cshtml`, `Delete.cshtml` : Formulaires pour la gestion des produits

4. **Services**
   - `Index.cshtml` : Liste des services avec organisation par catégorie
   - `Details.cshtml` : Détails d'un service
   - `Create.cshtml`, `Edit.cshtml`, `Delete.cshtml` : Formulaires pour la gestion des services

5. **VehiculeOccasion**
   - `Index.cshtml` : Liste des véhicules avec barre de recherche rapide
   - `Details.cshtml` : Détails d'un véhicule avec galerie d'images
   - `Recherche.cshtml` : Formulaire de recherche avancée
   - `ResultatsRecherche.cshtml` : Affichage des résultats de recherche
   - `Create.cshtml`, `Edit.cshtml`, `Delete.cshtml` : Formulaires pour la gestion des véhicules

6. **Devis**
   - `Create.cshtml` : Formulaire de demande de devis avec sélection de services
   - `Confirmation.cshtml` : Confirmation de soumission du devis

### Accès aux Données

1. **ApplicationDbContext.cs**
   - Classe qui hérite de `DbContext` pour gérer l'accès à la base de données
   - Configure les relations entre les entités
   - Définit les données de départ (seed data) pour les catégories, produits et services

2. **Migrations**
   - Système de migrations d'Entity Framework pour gérer les modifications de schéma
   - Migration initiale créée pour générer toutes les tables

## Fonctionnalités Principales

1. **Présentation du Garage**
   - Page d'accueil moderne et professionnelle
   - Section Histoire avec chronologie
   - Page Contact avec formulaire

2. **Catalogue de Produits**
   - Affichage par catégorie
   - Indication des promotions et du stock
   - Vue détaillée des produits

3. **Offre de Services**
   - Organisation par catégorie
   - Prix estimatifs
   - Détails des services

4. **Véhicules d'Occasion**
   - Liste complète des véhicules disponibles
   - Recherche avancée (marque, modèle, année, prix...)
   - Fiches détaillées des véhicules

5. **Système de Devis en Ligne**
   - Formulaire de demande personnalisé
   - Sélection des services souhaités
   - Confirmation automatique

## Architecture Technique

1. **Séparation des Responsabilités**
   - **Modèles** : Définition des entités et de la logique métier
   - **Vues** : Présentation des données et interface utilisateur
   - **Contrôleurs** : Traitement des requêtes et coordination

2. **Entity Framework Core**
   - Approche Code First pour la définition de la base de données
   - Relations bien définies entre les entités (one-to-many, many-to-many)
   - Utilisation de migrations pour gérer l'évolution du schéma

3. **Accès aux Données Asynchrone**
   - Utilisation des méthodes async/await pour toutes les opérations de base de données
   - Optimisation des performances avec chargement anticipé (Include)

4. **Design Responsive**
   - Interface adaptée à tous les appareils (mobile, tablette, desktop)
   - Utilisation de Bootstrap pour une mise en page cohérente

## Défis Techniques et Solutions

1. **Intégration des Noms de Propriétés**
   - **Défi** : Incohérences entre les noms de propriétés dans les modèles (ex: `CategorieId` vs `CategorieProduitId`)
   - **Solution** : Harmonisation des noms de propriétés dans tous les modèles, contrôleurs et vues

2. **Gestion des Nombres Décimaux Nullables**
   - **Défi** : Erreur lors de l'utilisation de `.HasValue` sur des decimal non nullables dans la vue des devis
   - **Solution** : Modification de la vérification en utilisant une comparaison avec zéro (`service.PrixEstimatif > 0`)

3. **Sections de Vue Non Rendues**
   - **Défi** : Erreur concernant la section `Styles` définie mais non rendue
   - **Solution** : Ajout de `@await RenderSectionAsync("Styles", required: false)` dans le layout principal

4. **Connexion à SQL Server Express**
   - **Défi** : Problèmes de certificat SSL lors de la connexion à SQL Server Express
   - **Solution** : Ajout du paramètre `TrustServerCertificate=True` dans la chaîne de connexion

## Évolutions Possibles

1. **Authentification et Autorisation**
   - Mise en place d'un système d'authentification pour les administrateurs
   - Sécurisation des actions d'administration (CRUD)

2. **Dashboard Administratif**
   - Création d'une interface d'administration centralisée
   - Statistiques et rapports sur les ventes et les devis

3. **Système de Réservation**
   - Ajout d'un calendrier pour la prise de rendez-vous en ligne
   - Gestion des créneaux disponibles

4. **Internationalisation**
   - Support multilingue pour étendre la clientèle

## Guide Technique de Déploiement

1. **Prérequis**
   - .NET 8.0 SDK
   - SQL Server (LocalDB ou SQL Express)
   - Visual Studio 2022 (recommandé) ou VS Code

2. **Étapes de Déploiement**
   - Cloner le dépôt ou décompresser l'archive du projet
   - Ouvrir la solution (.sln) dans Visual Studio
   - Vérifier/modifier la chaîne de connexion dans appsettings.json
   - Exécuter les migrations (`dotnet ef database update`)
   - Démarrer l'application (`dotnet run` ou F5 dans Visual Studio)

3. **Configuration Production**
   - Modification du mode d'environnement (`ASPNETCORE_ENVIRONMENT=Production`)
   - Configuration des secrets en dehors du code source
   - Optimisation des performances (mise en cache, minification des ressources)

## Conclusion

Le projet Garage Carr'auto est une application web complète qui démontre l'utilisation efficace du framework ASP.NET Core MVC, Entity Framework Core, et des techniques modernes de développement web. L'architecture bien structurée permet une maintenance facile et des évolutions futures.

L'application répond parfaitement aux besoins d'un garage automobile souhaitant présenter ses services, produits et véhicules en ligne, tout en offrant à ses clients la possibilité de demander des devis de manière simple et rapide.
