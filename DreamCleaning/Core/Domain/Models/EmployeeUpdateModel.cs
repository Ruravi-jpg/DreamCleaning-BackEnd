using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Core.Domain.Models
{
    public class EmployeeUpdateModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string RefStreet1 { get; set; }
        public string RefStreet2 { get; set; }
        public string Comments { get; set; }

        public EmployeeUpdateModel()
        {

        }

        public EmployeeUpdateModel(string name, string lastName, string streetAddress, string ref1, string ref2, string comments)
        {
            Name = name;
            LastName = lastName;
            StreetAddress = streetAddress;
            RefStreet1 = ref1;
            RefStreet2 = ref2;
            Comments = comments;
        }
    }
}
