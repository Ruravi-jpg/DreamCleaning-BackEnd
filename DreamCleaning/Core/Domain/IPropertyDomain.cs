using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace DC.WebApi.Core.Domain
{
    public interface IPropertyDomain
    {
        Task<List<PropertyEntity>> GetAllAsync(CancellationToken token);
        Task<List<PropertyEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<PropertyEntity> FindByIdAsync(long idProp, CancellationToken token);
        Task<PropertyEntity> FindByAsync(string alias, CancellationToken token);
        Task<int> UpdateAsync(PropertyEntity propId, PropertyUpdateModel property, CancellationToken token);
        Task<int> DeleteAsync(PropertyEntity property, CancellationToken token);
        Task<PropertyEntity> FindInactiveByIdAsync(long idProp, CancellationToken token);
        Task<PropertyEntity> CreatePropertyAsync(PropertyCreateModel property, CancellationToken token);
        Task<int> AddPhotosAsync(IFormFileCollection photos, PropertyEntity propDb, CancellationToken token);
        Task<string> GetImagesPath(long id, string guid, CancellationToken token);
        Task<int> CreateWorkUnit(PropertyEntity porpDb, List<WorkUnitCreateModel> workUnit, CancellationToken token);
        Task<int> UpdateWorkUnit(WorkUnitEntity workUnitDb, WorkUnitUpdateModel workUnituUpdate, CancellationToken token);
        Task<WorkUnitEntity> FindWorkUnitByIdAsync(long workUnitId, CancellationToken token);
        Task<List<WorkUnitEntity>> GetPropertyWorkunitsAsync(long propId, CancellationToken token);
        Task<List<WorkUnitEntity>> GetEmployeeWorkunitsAsync(long employeeId, CancellationToken token);
        Task<int> DeleteWorkUnitAsync(WorkUnitEntity workUnit, CancellationToken token);
    }
}
