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
    public class EducationCategoryRepository : GenericRepository<EducationCategory>, IEducationCategoryRepository
    {
        public EducationCategoryRepository(EmployeesManagerDbContext context) : base(context)
        {

        }

        //public EducationCategory GetEducationCategory(int id)
        //{
        //    return _context.EducationCategories.Include(x => x.Education).Where(x => x.EducationCategoryId == id).FirstOrDefault();
        //}
    }
}
