using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Api.Models
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string RefStreet1 { get; set; }
        public string RefStreet2 { get; set; }
        public string Comments { get; set; }

        public UserViewModel User { get; set; }

        public EmployeeViewModel(EmployeeEntity employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            LastName = employee.LastName;
            StreetAddress = employee.StreetAddress;
            RefStreet1 = employee.RefStreet1;
            RefStreet2 = employee.RefStreet2;
            Comments = employee.Comments;
            User = new UserViewModel(employee.UserEntity);
        }

        public static List<EmployeeViewModel> FromList(IReadOnlyList<EmployeeEntity> employees)
        {
            var list = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                list.Add(new EmployeeViewModel(employee));
            }

            return list;
        }

    }
}
