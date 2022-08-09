using DC.WebApi.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DC.WebApi.Core.Data.Repositories
{
    public class UserRepository : EntityRepository<UserEntity>, IUserRepository
    {

        public UserRepository(DCDbContext db) : base(db, db.Users)
        {

        }


        public Task<UserEntity> FindByAsync(string username, CancellationToken token)
        {
            return _context.Users
                .Where(X => X.IsActive == true)
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public Task<UserEntity> FindByIdAsync(long id, CancellationToken token)
        {
            return _context.Users
            .Where(x => x.IsActive == true)
            .SingleOrDefaultAsync(x => x.Id == id, token);
        }

        public Task<UserEntity> FindInactiveByIdAsync(long id, CancellationToken token)
        {
            return _context.Users
            .Where(x => x.IsActive == false)
            .SingleOrDefaultAsync(x => x.Id == id, token);
        }

        public Task<List<UserEntity>> GetAllAsync(CancellationToken token)
        {
            return _context.Users
            .Where(x => x.IsActive == true)
            .ToListAsync();
        }

        public Task<List<UserEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _context.Users
            .Where(x => x.IsActive == false)
            .ToListAsync();
        }
    }
}
