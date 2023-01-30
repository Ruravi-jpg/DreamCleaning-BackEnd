using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DC.WebApi.Api.Models
{
    public class WorkUnitViewModelProperty
    {

        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string DayToWork { get; set; }


        public WorkUnitViewModelProperty(WorkUnitEntity workUnit)
        {
            Id = workUnit.Id;
            EmployeeId = workUnit.EmployeeId; //new EmployeeViewModel(workUnit.Employee);
            StartTime = workUnit.StartTime.ToString(@"hh\:mm");
            FinishTime = workUnit.FinishTime.ToString(@"hh\:mm");
            DayToWork = workUnit.DayToWork.ToString();
        }

        public static List<WorkUnitViewModelProperty> FromList(IReadOnlyList<WorkUnitEntity> workUnits)
        {
            var list = new List<WorkUnitViewModelProperty>();
            foreach (var workUnit in workUnits)
            {
                list.Add(new WorkUnitViewModelProperty(workUnit));
            }

            return list;
        }
    }
}
