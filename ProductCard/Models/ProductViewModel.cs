using System.ComponentModel.DataAnnotations;

namespace ProductCard.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public string ProductId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Max Length should be hundred")]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
