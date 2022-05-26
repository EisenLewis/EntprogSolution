using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class RecipeVM
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage =
            "Recipe name must be at least 5 characters")]
        [MaxLength(50, ErrorMessage =
            "Recipe names cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage =
            "Description must be at least 5 characters")]
        [MaxLength(200, ErrorMessage =
            "Description cannot exceed 200 characters")]
        public string Description { get; set; }
        [Range(1, 10)]
        public int ServingSize { get; set; }
    }
}
