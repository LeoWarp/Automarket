using System.Linq;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;

namespace Automarket.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly ApplicationDbContext _db;

        public ProfileRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Profile entity)
        {
            await _db.Profiles.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _db.Profiles;
        }

        public Task Delete(Profile entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Profile> Update(Profile entity)
        {
            throw new System.NotImplementedException();
        }
    }
}