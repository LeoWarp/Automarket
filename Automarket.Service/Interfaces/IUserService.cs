using System.Collections.Generic;
using System.Threading.Tasks;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.User;

namespace Automarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(UserViewModel model);
        
        BaseResponse<Dictionary<int, string>> GetRoles();
        
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
        
        Task<IBaseResponse<bool>> DeleteUser(long id);
    }
}