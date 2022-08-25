using DC.WebApi.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DC.WebApi.Core.Data.Entities
{
    [Index(nameof(Name), nameof(LastName), IsUnique = true)]
    public class EmployeeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StreetAddress { get; set; }
        public string RefStreet1 { get; set; }
        public string RefStreet2 { get; set; }
        public string Comments { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public long UserEntityId { get; set; }

        [ForeignKey(nameof(UserEntityId))]
        public UserEntity UserEntity { get; set; }

        public EmployeeEntity()
        {

        }

        public EmployeeEntity(string name, string lastname, string address, string street1, string street2, string comments, long userEntityId)
        {
            Name = CleanNames.CleanName(name);
            LastName = CleanNames.CleanName(lastname);
            StreetAddress = CleanNames.CleanName(address);
            RefStreet1 = CleanNames.CleanName(street1);
            RefStreet2 = CleanNames.CleanName(street2);
            Comments = comments;
            UserEntityId = userEntityId;
            IsActive = true;
        }
    }

    
}
