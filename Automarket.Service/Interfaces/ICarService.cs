using System.Collections.Generic;
using System.Threading.Tasks;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();
        
        IBaseResponse<List<Car>> GetCars();
        
        Task<IBaseResponse<CarViewModel>> GetCar(long id);

        Task<BaseResponse<Dictionary<long, string>>> GetCar(string term);

        Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteCar(long id);

        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);
    }   
}