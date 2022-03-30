using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesManager.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

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
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
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

    }
}