using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        [Display(Name = "Šifra klinike")]
        public string NameShort { get; set; }
        [Display(Name = "Naziv klinike")]
        public string NameLong { get; set; }
        [Display(Name = "Predstojnik klinike")]
        public string HeadClinic { get; set; }
        [Display(Name = "Lokacija")]
        public Location Location { get; set; }

        //public IList<Institute> Institutes { get; set; }
    }

    public enum Location
    {
        [Display(Name = "Bijela zgrada, 1. kat")]
        bijelaZgrada1,
        [Display(Name = "Bijela zgrada, 2. kat")]
        bijelaZgrada2,
        [Display(Name = "Zelena zgrada, prizemlje")]
        zelenaZgradaPrizemlje,
        [Display(Name = "Zelena zgrada, suteren")]
        zelenaZgradaSuteren,
        [Display(Name = "Zelena zgrada, 1. kat")]
        zelenaZgrada1,
        [Display(Name = "Bijela zgrada, prizemlje")]
        bijelaZgradaPrizemlje
    }
}
