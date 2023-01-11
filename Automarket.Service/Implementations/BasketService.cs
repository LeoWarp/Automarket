using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Extensions;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Order;
using Automarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Service.Implementations;

public class BasketService : IBasketService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly IBaseRepository<Car> _carRepository;

    public BasketService(IBaseRepository<User> userRepository, IBaseRepository<Car> carRepository)
    {
        _userRepository = userRepository;
        _carRepository = carRepository;
    }

    public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName)
    {
        try
        {
            var user = await _userRepository.GetAll()
                .Include(x => x.Basket)
                .ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Name == userName);

            if (user == null)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Description = "Пользователь не найден",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            var orders = user.Basket?.Orders;
            var response = from p in orders
                join c in _carRepository.GetAll() on p.CarId equals c.Id
                select new OrderViewModel()
                {
                    Id = p.Id,
                    CarName = c.Name,
                    Speed = c.Speed,
                    TypeCar = c.TypeCar.GetDisplayName(),
                    Model = c.Model,
                    Image = c.Avatar
                };

            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Data = response,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id)
    {
        try
        {
            var user = await _userRepository.GetAll()
                .Include(x => x.Basket)
                .ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync(x => x.Name == userName);

            if (user == null)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = "Пользователь не найден",
                    StatusCode = StatusCode.UserNotFound
                };
            }
            
            var orders = user.Basket?.Orders.Where(x => x.Id == id).ToList();
            if (orders == null || orders.Count == 0)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = "Заказов нет",
                    StatusCode = StatusCode.OrderNotFound
                };
            }

            var response = (from p in orders
                join c in _carRepository.GetAll() on p.CarId equals c.Id
                select new OrderViewModel()
                {
                    Id = p.Id,
                    CarName = c.Name,
                    Speed = c.Speed,
                    TypeCar = c.TypeCar.GetDisplayName(),
                    Model = c.Model,
                    Address = p.Address,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MiddleName = p.MiddleName,
                    DateCreate = p.DateCreated.ToLongDateString(),
                    Image = c.Avatar
                }).FirstOrDefault();
            
            return new BaseResponse<OrderViewModel>()
            {
                Data = response,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<OrderViewModel>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}