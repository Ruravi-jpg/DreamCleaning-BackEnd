using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;
using Newtonsoft.Json.Linq;

namespace DC.WebApi.Core.Domain
{
    public interface IPropertyDomain
    {
        Task<List<PropertyEntity>> GetAllAsync(CancellationToken token);
        Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<PropertyEntity> FindByIdAsync(long idProp, CancellationToken token);
        Task<PropertyEntity> FindByAsync(string aliasProp, CancellationToken token);
        Task<int> UpdateAsync(PropertyEntity propId, PropertyUpdateModel property, CancellationToken token);
        Task<int> DeleteAsync(PropertyEntity property, CancellationToken token);
        Task<PropertyEntity> FindInactiveByIdAsync(long idProp, CancellationToken token);
        Task<PropertyEntity> CreatePropertyAsync(PropertyCreateModel property, CancellationToken token);
        Task<string> GetImagesPath(string alias, string guid, CancellationToken token);
    }
}
