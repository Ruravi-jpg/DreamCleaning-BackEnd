using DC.WebApi.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DC.WebApi.Api.Models
{
    public class PropertyViewModel
    {
        public long Id { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        public string BtwnStreet1 { get; set; }
        public string BtwnStreet2 { get; set; }
        public float HoursService { get; set; }
        public float CostService { get; set; }
        public string Comments { get; set; }
        public List<string> ReferencePhotosList { get; set; }
        public List<EmployeePropertyViewModel> EmployeesList { get; set; }

        public PropertyViewModel(PropertyEntity property)
        {
            Id = property.Id;
            Alias = property.Alias;
            Address = property.Address;
            BtwnStreet1 = property.BtwnStreet1;
            BtwnStreet2 = property.BtwnStreet2;
            HoursService = property.HoursService;
            CostService = property.CostService;
            Comments = property.Comments;

            foreach(var imagePath in property.ReferencePhotosList)
            {
                ReferencePhotosList.Add(Constants.GetImageGuid(imagePath));
            }
            ReferencePhotosList = property.ReferencePhotosList;

            EmployeesList = new List<EmployeePropertyViewModel>();
            foreach (var employee in property.PropertyEmployees)
            {
                EmployeesList.Add(new EmployeePropertyViewModel(employee));
            }
            
        }

        public static List<PropertyViewModel> FromList(IReadOnlyList<PropertyEntity> properties)
        {
            var list = new List<PropertyViewModel>();
            foreach (var property in properties)
            {
                list.Add(new PropertyViewModel(property));
            }

            return list;
        }
    }
}
