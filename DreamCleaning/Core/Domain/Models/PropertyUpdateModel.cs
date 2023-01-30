using DC.WebApi.Core.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace DC.WebApi.Core.Domain.Models
{
    public class PropertyUpdateModel
    {
        public string Alias { get; set; }
        public string Address { get; set; }
        public string BtwnStreet1 { get; set; }
        public string BtwnStreet2 { get; set; }
        public float HoursService { get; set; }
        public float CostService { get; set; }
        public string Comments { get; set; }
        public List<long> EmployeeList { get; set; }

        public PropertyUpdateModel()
        {
        }

        public PropertyUpdateModel(
            string alias,
            string address,
            string btwnStreet1,
            string btwnSrteet2,
            float hoursService,
            float costService,
            string comments,
            List<long> employeeList)
        {
            Alias = alias;
            Address = address;
            BtwnStreet1 = btwnStreet1;
            BtwnStreet2 = btwnSrteet2;
            HoursService = hoursService;
            CostService = costService;
            Comments = comments;
            EmployeeList = employeeList;
        }
    }
}
