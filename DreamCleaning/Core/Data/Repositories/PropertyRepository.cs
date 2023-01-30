using DC.WebApi.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
                .Include(x => x.WorkList)
                .FirstOrDefaultAsync(x => x.Alias == propAlias && x.IsActive == true, token);
        }

        public Task<PropertyEntity> FindByIdAsync(long idProp, CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.WorkList)
                .FirstOrDefaultAsync(x => x.Id == idProp && x.IsActive == true, token);
        }

        public Task<string> FindImagesUrl(long id, string guid, CancellationToken token)
        {

            var property = _context.Properties
                .Include(x => x.WorkList)
                .Where(x => x.Id == id)
                .Select(x => x.ReferencePhotosList).FirstOrDefault()
                  .Where(x => x.Contains(guid)).FirstOrDefault();

            return Task.FromResult(property);
        }

        public Task<PropertyEntity> FindInactiveByIdAsync(long idProp, CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.WorkList)
                .FirstOrDefaultAsync(x => x.Id == idProp && x.IsActive == false, token);
        }

        public Task<List<PropertyEntity>> GetAllAsync(CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.WorkList)
                .Where(x => x.IsActive == true).ToListAsync(token);
        }

        public Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _context.Properties
                .Include(x => x.WorkList)
                .Where(x => x.IsActive == false).ToListAsync(token);
        }

        
    }
}
