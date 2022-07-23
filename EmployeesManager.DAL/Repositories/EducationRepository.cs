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
    public class EducationRepository : GenericRepository<Education>, IEducationsRepository
    {
        public EducationRepository(EmployeesManagerDbContext context) : base(context)
        {
        }

        public Education GetEducation(int id)
        {
            return _context.Educations.Include(x => x.Employees).Where(x => x.EducationId == id).FirstOrDefault();
        }
    }
}
