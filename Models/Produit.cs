using System.ComponentModel.DataAnnotations;

namespace CarrAuto.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 10000, ErrorMessage = "Le prix doit être entre 0.01 et 10000")]
        public decimal Prix { get; set; }

        public decimal? PrixPromotion { get; set; }
        
        public bool EnPromotion { get; set; }
        
        public bool EstPopulaire { get; set; }
        
        public bool EnStock { get; set; } = true;
        
        public int QuantiteStock { get; set; }

        [StringLength(200)]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire")]
        public int CategorieProduitId { get; set; }
        public CategorieProduit? CategorieProduit { get; set; }
        
        public bool EstDisponible { get; set; } = true;
    }
}
