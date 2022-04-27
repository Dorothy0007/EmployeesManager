using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Workplace
    {
        public int WorkplaceId { get; set; }
        public string NameShort { get; set; }
        public string NameLong { get; set; }
        [Display(Name = "Mjesto troška")] 
        public string ExpenseCode { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
