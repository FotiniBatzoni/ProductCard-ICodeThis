using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCard.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(100, ErrorMessage = "Max Length should be hundred")]
        [MinLength(2, ErrorMessage = "Min Length should be 2")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Required Field")]
        [EmailAddress( ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(6, ErrorMessage = "Min Length should be 6")]
        [PasswordPropertyText]
        public string Password { get; set; }

        public string Token { get; set; }
        public string Role { get; set; }
    }
}
