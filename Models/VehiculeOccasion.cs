using System.ComponentModel.DataAnnotations;

namespace CarrAuto.Models
{
    public class VehiculeOccasion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire")]
        [StringLength(50, ErrorMessage = "La marque ne peut pas dépasser 50 caractères")]
        public string Marque { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le modèle est obligatoire")]
        [StringLength(50, ErrorMessage = "Le modèle ne peut pas dépasser 50 caractères")]
        public string Modele { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'année est obligatoire")]
        [Range(1950, 2050, ErrorMessage = "L'année doit être entre 1950 et l'année actuelle")]
        public int Annee { get; set; }

        [Required(ErrorMessage = "Le kilométrage est obligatoire")]
        [Range(0, 1000000, ErrorMessage = "Le kilométrage doit être entre 0 et 1 000 000")]
        public int Kilometrage { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0, 1000000, ErrorMessage = "Le prix doit être entre 0 et 1 000 000")]
        public decimal Prix { get; set; }

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string? Description { get; set; }

        [StringLength(100)]
        public string? Couleur { get; set; }

        [StringLength(100)]
        public string? TypeCarburant { get; set; }

        [StringLength(100)]
        public string? Transmission { get; set; }

        [StringLength(200)]
        public string? ImageUrl { get; set; }

        public string? ImagesSupplementaires { get; set; }

        public int? Puissance { get; set; }

        [StringLength(500)]
        public string? OptionsPrincipales { get; set; }

        public bool EstDisponible { get; set; } = true;

        public DateTime DateMiseEnVente { get; set; } = DateTime.Now;
    }
}
