using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Model
{
    public class ParticipationType
    {
        public int ParticipationTypeId { get; set; }
        [Display(Name = "Vrsta sudjelovanja")]
        public string ParticipationTypeName { get; set; }

       public ICollection<Education>? Education { get; set; }
    }
}
