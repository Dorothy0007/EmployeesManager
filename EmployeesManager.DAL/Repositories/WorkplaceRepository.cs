using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.DAL.Repositories
{
    public class WorkplaceRepository : GenericRepository<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(EmployeesManagerDbContext context) : base(context)
        {
        }
    }
}
