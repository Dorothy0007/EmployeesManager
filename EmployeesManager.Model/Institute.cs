using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Institute
    {
        public int InstituteId { get; set; }
        public string NameShort { get; set; }
        public string NameLong { get; set; }
        [Display(Name = "Pročelnik Zavoda")]
        public string HeadInstitute { get; set; }
        [Display(Name = "Mjesto troška")]
        public string ExpenseCode { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public IList<Department> Departments { get; set; }
    }
}
