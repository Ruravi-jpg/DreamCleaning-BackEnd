﻿using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Core.Domain.Models
{
    public class PropertyCreateModel
    {
        public string Address { get; set; }
        public string Alias { get; set; }
        public string BtwnStreet1 { get; set; }
        public string BtwnStreet2 { get; set; }
        public int HoursService { get; set; }
        public float CostService { get; set; }
        public string Comments { get; set; }
        public List<string> ReferencePhotosList { get; set; }
        public List<long> EmployeesList { get; set; }

        public PropertyCreateModel()
        {

        }

        public PropertyCreateModel(
            string alias,
            string address,
            string btwnStreet1,
            string btwnSrteet2,
            int hoursService,
            float costService,
            string comments,
            List<string> referencePhotosList,
            List<long> employeeIdList
            )
        {
            Alias = alias;
            Address = address;
            BtwnStreet1 = btwnStreet1;
            BtwnStreet2 = btwnSrteet2;
            HoursService = hoursService;
            CostService = costService;
            Comments = comments;
            ReferencePhotosList = referencePhotosList;
            EmployeesList = employeeIdList;
        }
    }
}
