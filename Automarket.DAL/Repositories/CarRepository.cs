using System.Linq;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;

namespace Automarket.DAL.Repositories
{
    public class CarRepository : IBaseRepository<Car>
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Car entity)
        {
            await _db.Cars.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Car> GetAll()
        {
            return _db.Cars;
        }

        public async Task Delete(Car entity)
        {
            _db.Cars.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Car> Update(Car entity)
        {
            _db.Cars.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}