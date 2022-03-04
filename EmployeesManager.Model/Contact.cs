using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public  class Contact
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }

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

        public virtual Employee Employee { get; set; }
    }
}
