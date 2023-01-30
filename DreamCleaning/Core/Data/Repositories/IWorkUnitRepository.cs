using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Core.Data.Repositories
{
    public interface IWorkUnitRepository : IEntityRepository<WorkUnitEntity>
    {
        Task<List<WorkUnitEntity>> GetAllAsync(CancellationToken token);
        Task<WorkUnitEntity> FindByIdAsync(long idWorkUnit, CancellationToken token);
        Task<List<WorkUnitEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<WorkUnitEntity> FindInactiveByIdAsync(long idWorkUnit, CancellationToken token);
        Task<List<WorkUnitEntity>> GetPropertyWorkUnits(long propId, CancellationToken token);
        Task<List<WorkUnitEntity>> GetEmployeeWorkUnits(long employeeId, CancellationToken token);
    }
}
