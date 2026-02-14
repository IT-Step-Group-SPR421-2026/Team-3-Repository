using System.ComponentModel.DataAnnotations;

namespace Shop_mvc_pv421.Models
{
    public class CreateProductModel
    {
        [Required, MinLength(3, ErrorMessage = "Title must has at least 3 characters.")]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "Title must start with a capital letter.")]
        public string Title { get; set; }
        public IFormFile? Image { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }
        public int Quantity { get; set; }

        [MinLength(10), MaxLength(3000)]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}
