using System.ComponentModel.DataAnnotations;

namespace BookingApp.WebApi.Models
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
