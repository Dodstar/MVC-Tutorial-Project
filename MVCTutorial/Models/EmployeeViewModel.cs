﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTutorial.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Forname")]
        public string Forname { get; set; }

        [Required(ErrorMessage = "Enter Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public Nullable<int> DepartmentId { get; set; }

        
        public string MiddleName { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        //Custom attribute
        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
        public string SiteName { get; set; }

        //Automapper ForMember Example
        public string ExtraValue { get; set; }
        public string CurrentDate { get; set; }

        public int AddressId { get; set; }
        public Nullable<int> HouseNumber { get; set; }
        public string HouseIdentifier { get; set; }
        public string HouseName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postcode { get; set; }
    }
}