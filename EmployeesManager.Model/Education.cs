using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Education
    {
        public int EducationId { get; set; }

        [Display(Name = "Naziv edukacije")]
        public string EducationName { get; set; }
       
        public int? EducationCategoryId { get; set; }
        [Display(Name = "Kategorija edukacije")]
        public string EducationCategory { get; set; }
        
        [Display(Name = "Vrsta edukacije")]
        public string EducationType { get; set; }
        
        [Display(Name = "Vrsta sudjelovanja")]
        public string ParticipationType { get; set; }
       
        [Display(Name = "Datum početka")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }
        
        [Display(Name = "Datum završetka")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
        
        [Display(Name = "Napomena")]
        public string Remark { get; set; }
        
        [Display(Name = "Obavezno")]
        public bool Mandatory { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
