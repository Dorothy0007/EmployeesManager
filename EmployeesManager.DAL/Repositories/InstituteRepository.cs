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
    public class InstituteRepository : GenericRepository<Institute>, IInstituteRepository
    {
        protected readonly EmployeesManagerDbContext _context;

        public InstituteRepository(EmployeesManagerDbContext context) : base(context)
        {
            
        }

        //public IEnumerable<Institute> GetAll()
        //{
        //    IList<Institute> institutes = _context.Institutes.Include(i => i.Clinic).ToList();
        //    return institutes;
        //}
    }
}
