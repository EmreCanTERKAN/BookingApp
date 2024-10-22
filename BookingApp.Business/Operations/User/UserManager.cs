using BookingApp.Business.Operations.User.Dtos;
using BookingApp.Business.Types;
using BookingApp.Data.Entities;
using BookingApp.Data.Repositories;
using BookingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.Operations.User
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());

            if (hasMail is not null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Kullanıcı mevcut, lütfen başka bir email deneyiniz."
                };
            }

            var userEntity = new UserEntity
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password, // şifreleme yapılacak
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
