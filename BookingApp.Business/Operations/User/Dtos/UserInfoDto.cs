
using BookingApp.Data.Enums;

namespace BookingApp.Business.Operations.User.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public UserType UserType { get; set; }

    }
}
