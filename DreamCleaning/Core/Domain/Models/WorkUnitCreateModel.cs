using DC.WebApi.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DC.WebApi.Core.Domain.Models
{
    public class WorkUnitCreateModel
    {
        public long EmployeeId { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public DayOfWeek DayToWork { get; set; }

        public WorkUnitCreateModel(long employeeId, string startTime, string finishTime, DayOfWeek dayToWork)
        {
            EmployeeId = employeeId;
            StartTime = ( startTime);
            FinishTime = ( finishTime);
            DayToWork = dayToWork;
        }
    }
}
