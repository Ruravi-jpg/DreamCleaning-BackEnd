using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Api.Models
{
    public class EmployeePropertyViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public EmployeePropertyViewModel(PropertyEmployeeEntity employee)
        {
            Id = employee.EmployeeId;
            Name = employee.Employee.Name;
            LastName = employee.Employee.LastName;
        }

    }
}
