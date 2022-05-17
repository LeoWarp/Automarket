using System;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Domain.ViewModels.Profile;
using Automarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Service.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IBaseRepository<Profile> _profileRepository;

        public ProfileService(IBaseRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IBaseResponse<Profile>> Get(string userName)
        {
            try
            {
                var car = await _profileRepository.GetAll()
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.User.Name == userName);
                if (car == null)
                {
                    return new BaseResponse<Profile>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                return new BaseResponse<Profile>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Profile>()
                {
                    Description = $"[Get] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<Profile>> Create(ProfileViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Car>> Edit(long id, ProfileViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}