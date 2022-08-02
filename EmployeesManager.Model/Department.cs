using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Display(Name = "Šifra odjela")]
        public string NameShort { get; set; }
        [Display(Name = "Naziv odjela")]
        public string NameLong { get; set; }
        [Display(Name = "Voditelj odjela")]
        public int HeadDepartmentId { get; set; }
        [Display(Name = "Mjesto troška")]
        public string ExpenseCode { get; set; }
        [Display(Name = "Šifra aktivnosti")]
        public string ActivityCode { get; set; }

        public int? InstituteId { get; set; }
        public Institute Institute{ get; set; }

        public ICollection<Workplace>? Workplaces { get; set; }
    }
}
