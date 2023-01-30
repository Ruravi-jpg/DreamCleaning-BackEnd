using DC.WebApi.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.IO.Pem;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DC.WebApi.Core.Data.Entities
{
    public class WorkUnitEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public EmployeeEntity Employee { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan FinishTime { get; set; }

        [Required]
        public DayOfWeek DayToWork { get; set; }
        public PropertyEntity PropertyParent { get; set; }

        public bool IsActive { get; set; }


        public WorkUnitEntity()
        {

        }

        public WorkUnitEntity(long employeeId, TimeSpan startTime, TimeSpan finishTime, DayOfWeek dayToWork)
        {
            EmployeeId = employeeId;
            StartTime = startTime;
            FinishTime = finishTime;
            DayToWork = dayToWork;
            IsActive = true;
        }
    }
}
