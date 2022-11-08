using DC.WebApi.Core.Data.Entities;
using Newtonsoft.Json.Linq;

namespace DC.WebApi.Core.Data.Repositories
{
    public interface IPropertyRepository : IEntityRepository<PropertyEntity>
    {
        Task<List<PropertyEntity>> GetAllAsync(CancellationToken token);
        Task<PropertyEntity> FindByAsync(string propAlias, CancellationToken token);
        Task<PropertyEntity> FindByIdAsync(long idProp, CancellationToken token);
        Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<PropertyEntity> FindInactiveByIdAsync(long idProp, CancellationToken token);
        Task<string> FindImagesUrl(string alias, string guid, CancellationToken token);
    }
}
