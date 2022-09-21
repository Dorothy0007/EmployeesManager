using EmployeesManager.Model;
using Microsoft.EntityFrameworkCore;
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

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Include(x => x.Healthcares).Where(x => x.EmployeeId == id).FirstOrDefault();
        }

        public Employee GetEmployeeEducations(int id)
        {
            return _context.Employees.Include(x => x.Educations).Where(x => x.EmployeeId == id).FirstOrDefault();
        }
    }
    public class HealthCareRepository : GenericRepository<Healthcare>, IHealthCareRepository
    {
        public HealthCareRepository(EmployeesManagerDbContext context) : base(context)
        {

        }

        public List<Healthcare> GetHealthCare(int id)
        {
            return _context.Healthcares.Where(x => x.EmployeeId == id).ToList();
        }
    }
}
