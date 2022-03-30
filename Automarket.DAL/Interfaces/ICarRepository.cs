using System.Threading.Tasks;
using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}