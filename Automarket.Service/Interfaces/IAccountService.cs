using System.Security.Claims;
using System.Threading.Tasks;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Account;

namespace Automarket.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}