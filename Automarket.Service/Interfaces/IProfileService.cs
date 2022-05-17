using System.Threading.Tasks;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Domain.ViewModels.Profile;

namespace Automarket.Service.Interfaces
{
    public interface IProfileService
    {
        Task<IBaseResponse<Profile>> Get(string userName);

        Task<IBaseResponse<Profile>> Create(ProfileViewModel model);
        
        Task<IBaseResponse<Car>> Edit(long id, ProfileViewModel model);
    }
}