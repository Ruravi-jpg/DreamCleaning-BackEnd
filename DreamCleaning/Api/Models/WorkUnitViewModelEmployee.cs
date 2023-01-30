using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DC.WebApi.Api.Models
{
    public class WorkUnitViewModelEmployee
    {

        public long Id { get; set; }
        public PropertyViewModel Property { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public DayOfWeek DayToWork { get; set; }


        public WorkUnitViewModelEmployee(WorkUnitEntity workUnit)
        {
            Id = workUnit.Id;
            Property = new PropertyViewModel(workUnit.PropertyParent);
            StartTime= workUnit.StartTime;
            FinishTime= workUnit.FinishTime;
            DayToWork= workUnit.DayToWork;
        }

        public static List<WorkUnitViewModelEmployee> FromList(IReadOnlyList<WorkUnitEntity> workUnits)
        {
            var list = new List<WorkUnitViewModelEmployee>();
            foreach (var workUnit in workUnits)
            {
                list.Add(new WorkUnitViewModelEmployee(workUnit));
            }

            return list;
        }
    }
}
