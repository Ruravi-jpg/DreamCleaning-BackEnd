using DC.WebApi.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DC.WebApi.Core.Data.Repositories
{
    public class PropertyRepository : EntityRepository<PropertyEntity>, IPropertyRepository
    {
        public PropertyRepository(DCDbContext db) : base(db, db.Properties)
        {
        }

        public Task<PropertyEntity> FindByAsync(string propAlias, CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.PropertyEmployees)
                    .ThenInclude(y => y.Employee)
                .FirstOrDefaultAsync(x => x.Alias == propAlias && x.IsActive == true, token);
        }

        public Task<PropertyEntity> FindByIdAsync(long idProp, CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.PropertyEmployees)
                    .ThenInclude(y => y.Employee)
                .FirstOrDefaultAsync(x => x.Id == idProp && x.IsActive == true, token);
        }

        public Task<PropertyEntity> FindInactiveByIdAsync(long idProp, CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.PropertyEmployees)
                    .ThenInclude(y => y.Employee)
                .FirstOrDefaultAsync(x => x.Id == idProp && x.IsActive == false, token);
        }

        public Task<List<PropertyEntity>> GetAllAsync(CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.PropertyEmployees)
                    .ThenInclude(y => y.Employee)
                .Where(x => x.IsActive == true).ToListAsync(token);
        }

        public Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.PropertyEmployees)
                    .ThenInclude(y => y.Employee)
                .Where(x => x.IsActive == false).ToListAsync(token);
        }
    }
}
