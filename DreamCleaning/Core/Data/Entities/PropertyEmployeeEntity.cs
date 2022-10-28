using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DC.WebApi.Core.Data.Entities
{
    public class PropertyEmployeeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long PropertyId { get; set; }
        [Required]
        public long EmployeeId { get; set; }



        [ForeignKey(nameof(PropertyId))]
        public PropertyEntity Property { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public EmployeeEntity Employee { get; set; }

        public PropertyEmployeeEntity()
        {

        }

        public PropertyEmployeeEntity(long employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
