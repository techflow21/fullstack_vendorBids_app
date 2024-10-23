using System.ComponentModel.DataAnnotations;

namespace VendorBiddingApp_Backend.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
