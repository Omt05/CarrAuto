using System.ComponentModel.DataAnnotations;

namespace CarrAuto.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du service est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string Description { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Le prix doit être entre 0 et 10000")]
        public decimal? PrixEstimatif { get; set; }

        [StringLength(200)]
        public string? ImageUrl { get; set; }
        
        [StringLength(500)]
        public string? DetailsSupplementaires { get; set; }
        
        public bool EstPopulaire { get; set; }

        public int CategorieServiceId { get; set; }
        public CategorieService? CategorieService { get; set; }
    }
}
