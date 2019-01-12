using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTutorial.Domain
{
    class AddressDomainModel
    {
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
