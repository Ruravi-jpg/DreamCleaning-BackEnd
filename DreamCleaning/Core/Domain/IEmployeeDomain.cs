using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Core.Domain
{
    public interface IEmployeeDomain
    {
        Task<List<EmployeeEntity>> GetAllAsync(CancellationToken token);
        Task<List<EmployeeEntity>> GetAllInactiveAsync(CancellationToken token);
        Task<EmployeeEntity> FindByIdAsync(long idEmp, CancellationToken token);
        Task<EmployeeEntity> FindByAsync(long userEntityId, CancellationToken token);
        Task<int> UpdateAsync(EmployeeEntity employeeDb, EmployeeUpdateModel employee, CancellationToken token);
        Task<int> DeleteAsync(EmployeeEntity employee, CancellationToken token);
        Task<EmployeeEntity> FindInactiveByIdAsync(long idEmp, CancellationToken token);
        Task<EmployeeEntity> CreateEmployeeAsync(EmployeeCreateModel employee, CancellationToken token);
    }
}
