using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Core.Domain.Models
{
    public class EmployeeCreateModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string RefStreet1 { get; set; }
        public string RefStreet2 { get; set; }
        public string Comments { get; set; }
        public UserCreateModel User { get; set; }

        public EmployeeCreateModel()
        {

        }

        public EmployeeCreateModel(string name, string lastname, string addres, string ref1, string ref2, string comments, UserCreateModel user)
        {
            Name = name;
            LastName = lastname;
            StreetAddress = addres;
            RefStreet1 = ref1;
            RefStreet2 = ref2;
            Comments = comments;
            User = user; 
        }
    }
}
