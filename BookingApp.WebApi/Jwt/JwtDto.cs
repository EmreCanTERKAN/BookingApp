using BookingApp.Data.Enums;

namespace BookingApp.WebApi.Jwt
{
    public class JwtDto
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public UserType UserType { get; set; }
        public String SecretKey { get; set; }
        public String Issuer { get; set; }
        public String Audience { get; set; }
        public int ExpireMinutes { get; set; }
    }
}
