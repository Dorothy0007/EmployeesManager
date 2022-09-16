using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesManager.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Potrebno upisati ime!")]
        public string FirstName { get; set; }


        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Potrebno upisati prezime!")]
        public string LastName { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "OIB mora sadržavati 11 znamenaka.")]
        [Required(ErrorMessage = "Potrebno upisati OIB!")]
        public string OIB { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "MBO mora sadržavati 9 znamenaka.")]
        [Required(ErrorMessage = "Potrebno upisati MBO!")]
        public string MBO { get; set; }

        [Display(Name = "Aktivnost")]
        public bool Active { get; set; }

        [Display(Name = "Datum rođenja")]
        [Required(ErrorMessage = "Potrebno upisati datum rođenja!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Kućni broj")]
        public string StreetNumber { get; set; }
        [Display(Name = "Poštanski broj")]
        public int PostalCode { get; set; }
        [Display(Name = "Grad")]
        public string City { get; set; }
        [Display(Name = "Država")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Privatna adresa e-pošte")]
        [EmailAddress(ErrorMessage = "Neispravan format adrese e-pošte.")]
        public string PrivateEmail { get; set; }

        [Required]
        [Display(Name = "Poslovna adresa e-pošte")]
        [EmailAddress(ErrorMessage = "Neispravan format adrese e-pošte.")]
        public string BusinessEmail { get; set; }

        [Display(Name = "Broj fiksne poslovne linije")]
        public string BusinessTelephone { get; set; }

        [Display(Name = "Poslovni broj mobitela")]
        public string BusinessMobilePhone { get; set; }

        [Display(Name = "Privatni broj mobitela")]
        public string PrivateMobilePhone { get; set; }

        public ICollection<Healthcare>? Healthcares { get; set; }

        public ICollection<Education>? Educations { get; set; }
    }
}