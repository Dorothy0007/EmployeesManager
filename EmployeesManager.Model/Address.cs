using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
