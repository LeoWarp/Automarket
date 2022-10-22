using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Order;

namespace Automarket.Service.Interfaces
{
    public interface IBasketService
    {
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);

        Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
    }   
}