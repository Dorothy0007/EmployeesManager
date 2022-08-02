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
    public class EducationTypeRepository : GenericRepository<EducationType>, IEducationTypeRepository
    {
        public EducationTypeRepository(EmployeesManagerDbContext context) : base(context)
        {

        }
    }
}
