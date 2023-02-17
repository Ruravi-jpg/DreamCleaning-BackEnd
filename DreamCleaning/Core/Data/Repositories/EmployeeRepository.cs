using DC.WebApi.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DC.WebApi.Core.Data.Repositories
{
    public class EmployeeRepository : EntityRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(DCDbContext db) : base(db, db.Employees)
        {
        }


        public Task<EmployeeEntity> FindByAsync(long userEntityid, CancellationToken token)
        {
            return _context.Employees
                .Include(x => x.UserEntity)
                .FirstOrDefaultAsync(x => x.UserEntity.Id == userEntityid && x.IsActive == true , token);
        }

        public Task<EmployeeEntity> FindByIdAsync(long idEmp, CancellationToken token)
        {
            return _context.Employees
                .Include(x => x.UserEntity)
                .FirstOrDefaultAsync(x => x.Id == idEmp && x.IsActive == true , token);
        }

        public Task<EmployeeEntity> FindByUserIdAsync(long idUser, CancellationToken token)
        {
            return _context.Employees
                .Include(x => x.UserEntity)
                .FirstOrDefaultAsync(x => x.UserEntityId == idUser && x.IsActive == true , token);
        }

        public Task<EmployeeEntity> FindInactiveByIdAsync(long idEmp, CancellationToken token)
        {
            return _context.Employees
                .Include(x => x.UserEntity)
                .FirstOrDefaultAsync(x => x.Id == idEmp && x.IsActive == false, token);
        }

        public Task<List<EmployeeEntity>> GetAllAsync(CancellationToken token)
        {
            return _context.Employees
                .Include(x => x.UserEntity)
                .Where(x => x.IsActive == true).ToListAsync(token);
        }

        public Task<List<EmployeeEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _context.Employees
                .Include(x => x.UserEntity)
                .Where(x => x.IsActive == false).ToListAsync(token);
        }
    }
}
