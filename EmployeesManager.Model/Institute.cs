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
        [Display(Name = "Šifra Zavoda")]
        public string NameShort { get; set; }
        [Display(Name = "Naziv Zavoda")]
        public string NameLong { get; set; }
        [Display(Name = "Pročelnik Zavoda")]
        public string HeadInstitute { get; set; }
        [Display(Name = "Mjesto troška")]
        public string ExpenseCode { get; set; }

        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<Department>? Departments { get; set; }
    }
}
