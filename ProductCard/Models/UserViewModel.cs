using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCard.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Max Length should be hundred")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
