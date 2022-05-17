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
        
        Task<IBaseResponse<CarViewModel>> GetCar(int id);

        Task<BaseResponse<Dictionary<int, string>>> GetCar(string term);

        Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
    }   
}