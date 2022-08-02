using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class EducationCategory
    {
        public int EducationCategoryId { get; set; }
        [Display(Name = "Naziv kategorije edukacije")]
        public string CategoryName { get; set; }

       public ICollection<Education>? Education { get; set; }
    }
}