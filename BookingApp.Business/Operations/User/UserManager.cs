using BookingApp.Business.DataProtection;
using BookingApp.Business.Operations.User.Dtos;
using BookingApp.Business.Types;
using BookingApp.Data.Entities;
using BookingApp.Data.Repositories;
using BookingApp.Data.UnitOfWork;

namespace BookingApp.Business.Operations.User
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtection _dataProtector;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository, IDataProtection dataProtector)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtector = dataProtector;
        }
        
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());

            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Email mevcut, lütfen başka bir email deneyiniz."
                };
            }

            var userEntity = new UserEntity 
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = _dataProtector.Protect(user.Password),
                BirthDate = user.BirthDate,

            };

            _userRepository.Add(userEntity);
            try
            {
               await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Kullanıcı kaydı sırasında bir hata oluştu.");
            }
            
            return new ServiceMessage
            {
                IsSucceed= true,
                Message = "Kullanıcı başarıyla oluşturuldu."
            };

        }
    }
}
