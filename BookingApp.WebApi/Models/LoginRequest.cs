using System.ComponentModel.DataAnnotations;

namespace BookingApp.WebApi.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
