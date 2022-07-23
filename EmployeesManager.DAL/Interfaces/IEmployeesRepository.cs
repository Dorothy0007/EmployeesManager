using EmployeesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.DAL
{
    public interface IEmployeesRepository : IGenericRepository<Employee>
    {
        //popis metoda za implementaciju, specifičnih za Employee entitet uz već dodane generičke metode
        Employee GetEmployee(int id);
    }
    public interface IHealthCareRepository : IGenericRepository<Healthcare>
    {
        List<Healthcare> GetHealthCare(int id);
    }
}
