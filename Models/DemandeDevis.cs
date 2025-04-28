using System.ComponentModel.DataAnnotations;

namespace CarrAuto.Models
{
    public class DemandeDevis
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères")]
        public string Prenom { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide")]
        [StringLength(100, ErrorMessage = "L'email ne peut pas dépasser 100 caractères")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Veuillez entrer un numéro de téléphone valide")]
        [StringLength(20, ErrorMessage = "Le téléphone ne peut pas dépasser 20 caractères")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "La marque du véhicule est obligatoire")]
        [StringLength(50, ErrorMessage = "La marque ne peut pas dépasser 50 caractères")]
        public string MarqueVehicule { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le modèle du véhicule est obligatoire")]
        [StringLength(50, ErrorMessage = "Le modèle ne peut pas dépasser 50 caractères")]
        public string ModeleVehicule { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'année du véhicule est obligatoire")]
        [Range(1950, 2050, ErrorMessage = "L'année doit être entre 1950 et l'année actuelle")]
        public int AnneeVehicule { get; set; }

        [Required(ErrorMessage = "La description des travaux est obligatoire")]
        [StringLength(1000, ErrorMessage = "La description ne peut pas dépasser 1000 caractères")]
        public string DescriptionTravaux { get; set; } = string.Empty;

        public DateTime DateDemande { get; set; } = DateTime.Now;

        public string? Statut { get; set; } = "En attente";

        public decimal? MontantDevis { get; set; }

        public string? CommentairesInternes { get; set; }
    }
}
