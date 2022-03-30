using System.Collections.Generic;
using System.Threading.Tasks;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
        
        Task<IBaseResponse<CarViewModel>> GetCar(int id);

        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<Car>> GetCarByName(string name);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
    }   
}