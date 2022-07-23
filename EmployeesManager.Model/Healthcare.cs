using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class Healthcare
    {
        public Healthcare()
        {

        }
        public int HealthcareId { get; set; }
        public string HealthcareName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ValidUntil { get; set; }
        public string Remark { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    public enum HealthcareName
    {
        [Display(Name = "Cijepljenje HBs Ag")]
        CijepljenjeHBsAg,
        [Display(Name = "Sistematski Pregled")]
        SistematskiPregled,
        [Display(Name = "Cijepljenje Protiv Gripe")]
        CijepljenjeProtivGripe,
        [Display(Name = "Cijepljenje SARS Cov 2")]
        CijepljenjeSARSCov2
    }
}
