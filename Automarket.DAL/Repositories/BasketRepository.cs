using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;

namespace Automarket.DAL.Repositories
{
    public class BasketRepository : IBaseRepository<Basket>
    {
        private readonly ApplicationDbContext _dbContext;

        public BasketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Basket> GetAll()
        {
            return _dbContext.Baskets;
        }

        public Task Delete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> Update(Basket entity)
        {
            throw new NotImplementedException();
        }
        
        public Task Create(Basket entity)
        {
            throw new NotImplementedException();
        }
    }   
}