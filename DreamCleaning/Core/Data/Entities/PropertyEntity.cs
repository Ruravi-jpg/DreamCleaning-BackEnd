using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DC.WebApi.Api.Services;

namespace DC.WebApi.Core.Data.Entities
{
    [Index(nameof(Alias), IsUnique = true)]
    public class PropertyEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public string Address { get; set; }
        public string BtwnStreet1 { get; set; }
        public string BtwnStreet2 { get; set; }
        [Required]
        public float HoursService { get; set; }
        [Required]
        public float CostService { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public List<string> ReferencePhotosList { get; set; }

        public List<PropertyEmployeeEntity> PropertyEmployees { get; set; }

        public PropertyEntity()
        {

        }

        public PropertyEntity(
            string alias,
            string address,
            string btwnStreet1,
            string btwnStreet2,
            float hoursService,
            float costService,
            string comments
            )
        {
            Alias = CleanNames.CleanName(alias);
            Address = CleanNames.CleanName(address);
            BtwnStreet1 = CleanNames.CleanName(btwnStreet1);
            BtwnStreet2 = CleanNames.CleanName(btwnStreet2);
            HoursService = hoursService;
            CostService = costService;
            Comments = comments;
            PropertyEmployees = new List<PropertyEmployeeEntity>();

            IsActive = true;

        }
    }

}
