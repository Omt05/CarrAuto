using System.ComponentModel.DataAnnotations;

namespace CarrAuto.Models
{
    public class CategorieProduit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la catégorie est obligatoire")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string Nom { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "La description ne peut pas dépasser 200 caractères")]
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Produit>? Produits { get; set; }
    }
}
