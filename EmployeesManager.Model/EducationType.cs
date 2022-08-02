using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class EducationType
    {
        public int EducationTypeId { get; set; }
        [Display(Name = "Vrsta edukacije")]
        public string EducationTypeName { get; set; }

       public ICollection<Education>? Education { get; set; }
    }
}
