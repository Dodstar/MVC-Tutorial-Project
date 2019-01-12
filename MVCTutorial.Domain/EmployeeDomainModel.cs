using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTutorial.Domain
{
    public class EmployeeDomainModel
    {

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Forname")]
        public string Forname { get; set; }

        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public int ExtraValue { get; set; }
        public DateTime CurrentDate { get; set; }

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
