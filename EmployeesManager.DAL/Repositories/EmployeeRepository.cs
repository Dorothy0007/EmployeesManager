using EmployeesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.DAL
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        public EmployeeRepository(EmployeesManagerDbContext context) : base(context)
        {

        }
    }
}
