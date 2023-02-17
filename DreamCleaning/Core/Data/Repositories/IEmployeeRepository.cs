using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Core.Data.Repositories
{
    public interface IEmployeeRepository : IEntityRepository<EmployeeEntity>
    {
        Task<List<EmployeeEntity>> GetAllAsync(CancellationToken token);
        Task<EmployeeEntity> FindByIdAsync(long idEmp, CancellationToken token);
        Task<EmployeeEntity> FindByUserIdAsync(long idUser, CancellationToken token);
        Task<EmployeeEntity> FindByAsync(long userEntityid, CancellationToken token);
        Task<List<EmployeeEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<EmployeeEntity> FindInactiveByIdAsync(long idEmp, CancellationToken token);
    }
}
