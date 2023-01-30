using DC.WebApi.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DC.WebApi.Core.Data.Repositories
{
    public class WorkUnitRepository : EntityRepository<WorkUnitEntity>, IWorkUnitRepository
    {
        public WorkUnitRepository(DCDbContext db) : base(db, db.WorkUnits)
        {
        }

        public Task<WorkUnitEntity> FindByIdAsync(long idWorkUnit, CancellationToken token)
        {
            return _context.WorkUnits
                .Include(x=>x.PropertyParent)
                .Include(x => x.Employee)
                    .ThenInclude(y => y.UserEntity)
                .FirstOrDefaultAsync(x => x.Id == idWorkUnit && x.IsActive == true, token);
        }

        public Task<WorkUnitEntity> FindInactiveByIdAsync(long idWorkUnit, CancellationToken token)
        {
            return _context.WorkUnits
                .Include(x => x.PropertyParent)
                .Include(x => x.Employee)
                    .ThenInclude(y => y.UserEntity)
                .FirstOrDefaultAsync(x => x.Id == idWorkUnit && x.IsActive == false, token);
        }

        public Task<List<WorkUnitEntity>> GetAllAsync(CancellationToken token)
        {
            return _context.WorkUnits
                .Include(x => x.PropertyParent)
                .Include(x => x.Employee)
                    .ThenInclude(y => y.UserEntity)
                .Where(x => x.IsActive == true).ToListAsync(token);
        }

        public Task<List<WorkUnitEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _context.WorkUnits
                .Include(x => x.PropertyParent)
                .Include(x => x.Employee)
                    .ThenInclude(y => y.UserEntity)
                .Where(x => x.IsActive == false).ToListAsync(token);
        }

        public Task<List<WorkUnitEntity>> GetEmployeeWorkUnits(long employeeId, CancellationToken token)
        {
            return _context.WorkUnits
                .Include(x => x.PropertyParent)
                .Include(x => x.Employee)
                    .ThenInclude(y => y.UserEntity)
                .Where(x => x.EmployeeId == employeeId).ToListAsync(token);
        }

        public Task<List<WorkUnitEntity>> GetPropertyWorkUnits(long propId, CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.WorkList)
                    .ThenInclude(y => y.Employee)
                        .ThenInclude(z => z.UserEntity)
                .Include(x => x.WorkList)
                    .ThenInclude(y => y.PropertyParent)
                .Where(x => x.Id == propId && x.IsActive == true)
                .SelectMany(x => x.WorkList)
                .OrderBy(x =>x.Id)
                .ToListAsync(token);
        }
    }
}
