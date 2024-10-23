using BookingApp.Business.Operations.User.Dtos;
using BookingApp.Business.Types;

namespace BookingApp.Business.Operations.User
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user); // async çünkü unit of work pattern

        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user);
    }
}
