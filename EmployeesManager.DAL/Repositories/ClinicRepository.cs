using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.DAL.Repositories
{
    public class ClinicRepository : GenericRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(EmployeesManagerDbContext context) : base(context)
        {
        }

        public virtual IEnumerable<Clinic> GetAll()
        {
            return _context.Clinics.Include(i => i.Institutes).ToList();
        }
    }
}
