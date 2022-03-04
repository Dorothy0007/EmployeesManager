using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesManager.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "OIB mora sadržavati 11 znamenaka.")]
        public string OIB { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "MBO mora sadržavati 9 znamenaka.")]
        public string MBO { get; set; }

        [Display(Name = "Aktivnost")]
        public bool Active { get; set; } = true;

        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Adresa")]
        public virtual Address Address { get; set; }

        [Display(Name = "Kontakt")]
        public virtual Contact Contact { get; set; } 

        //[ForeignKey("Section")]
        //public int SectionId { get; set; }
        //public virtual Section Section { get; set; }

        //public virtual ICollection<EmployeeStay> EmployeeStays { get; set; }

    }
}