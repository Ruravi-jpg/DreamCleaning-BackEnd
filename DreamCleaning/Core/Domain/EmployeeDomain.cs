using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Data.Repositories;
using DC.WebApi.Core.Domain.Models;

namespace DC.WebApi.Core.Domain
{
    public class EmployeeDomain : IEmployeeDomain
    {
        private readonly IEmployeeRepository _repo;
        private readonly IUserDomain _userDomain;

        public EmployeeDomain(IEmployeeRepository repo, IUserDomain userDomain)
        {
            _repo = repo;
            _userDomain = userDomain;
        }
        public async Task<EmployeeEntity> CreateEmployeeAsync(EmployeeCreateModel employee, CancellationToken token)
        {
            using var transaction = _repo.BeginTransaction();

            employee.User.Role = UserRole.Employee;

            var user = await _userDomain.CreateAsync(employee.User, token);

            if (user == default)
                throw new ArgumentNullException(nameof(user));

            var employeeDb = new EmployeeEntity(employee.Name, employee.LastName, employee.StreetAddress, employee.RefStreet1, employee.RefStreet2, employee.Comments, user.Id);

            await _repo.AddAsync(employeeDb);

            await _repo.SaveChangesAsync();

            await transaction.CommitAsync(token);

            return employeeDb;
        }

        public async Task<int> DeleteAsync(EmployeeEntity employee, CancellationToken token)
        {
            if (employee == default)
                throw new ArgumentNullException(nameof(employee));

            employee.IsActive = false;
            employee.UserEntity.IsActive = false;
            
            _repo.Update(employee);

            return await _repo.SaveChangesAsync();
        }

        public Task<EmployeeEntity> FindByAsync(long userEntityId, CancellationToken token)
        {
            var employee = _repo.FindByAsync(userEntityId, token);

            if (employee == default)
                return default;
            return employee;
        }

        public Task<EmployeeEntity> FindByIdAsync(long idEmp, CancellationToken token)
        {
            var employee = _repo.FindByIdAsync(idEmp, token);

            if (employee == default)
                return default;

            return employee;
        }

        public Task<EmployeeEntity> FindByUserIdAsync(long idEmp, CancellationToken token)
        {
            var employee = _repo.FindByUserIdAsync(idEmp, token);

            if(employee == default)
                return default;

            return employee;
        }

        public Task<EmployeeEntity> FindInactiveByIdAsync(long idEmp, CancellationToken token)
        {
            var employee = _repo.FindInactiveByIdAsync(idEmp, token);

            if (employee == default)
                return default;

            return employee;
        }

        public Task<List<EmployeeEntity>> GetAllAsync(CancellationToken token)
        {
            return _repo.GetAllAsync(token);
        }

        public Task<List<EmployeeEntity>> GetAllInactiveAsync(CancellationToken token)
        {
            return _repo.GetAllInactiveAsync(token);
        }

        public async Task<int> UpdateAsync(EmployeeEntity employeeDb, EmployeeUpdateModel employee, CancellationToken token)
        {
            if (employeeDb == null)
                throw new ArgumentNullException(nameof(employeeDb));


            if (!String.IsNullOrEmpty(employee.Name))
                employeeDb.Name = employee.Name;

            if (!String.IsNullOrEmpty(employee.LastName))
                employeeDb.LastName = employee.LastName;

            if (!String.IsNullOrEmpty(employee.StreetAddress))
                employeeDb.StreetAddress = employee.StreetAddress;

            if (!String.IsNullOrEmpty(employee.RefStreet1))
                employeeDb.RefStreet1 = employee.RefStreet1;

            if (!String.IsNullOrEmpty(employee.RefStreet2))
                employeeDb.RefStreet2 = employee.RefStreet2;

            if (!String.IsNullOrEmpty(employee.Comments))
                employeeDb.Comments = employee.Comments;

            _repo.Update(employeeDb);

            return await _repo.SaveChangesAsync();
        }
    }
}
