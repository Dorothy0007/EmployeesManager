using EmployeesManager.DAL;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeesManager.Web.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeesManagerDbContext _db;

        public EmployeeController(EmployeesManagerDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _db.Employees;
            return View(employeeList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
           
            //employee.Contact.Employee = employee;
            //employee.Address.Employee = employee;

            //ModelState.Clear();
            //TryValidateModel(employee);
            //TryValidateModel(employee.Contact);
            //TryValidateModel(employee.Address);

            if (ModelState.IsValid)
            {

                _db.Employees.Add(employee);
                _db.SaveChanges();
                TempData["success"] = "Uspješno dodavanje novog zaposlenika!";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            //var emp = _db.Employees.Find(id);

            var emp = await _db.Employees
                .Include(e => e.Address).Include(e => e.Contact).FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            //employee.Contact.EmployeeId = employee.EmployeeId;
            //employee.Address.EmployeeId = employee.EmployeeId;

            //employee.Contact.Employee = employee;
            //employee.Address.Employee = employee;

            //if (ModelState.IsValid)
            //{
            //    _db.Employees.Update(employee);
            //    _db.SaveChanges();
            //    TempData["success"] = "Uspješno ažuriranje zaposlenika!";
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(employee);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Uspješno ažuriranje zaposlenika!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["EmployeeId"] = new SelectList(_db.Set<Address>(), "EmployeeId", "EmployeeId", employee.Address.EmployeeId);
            //ViewData["EmployeeId"] = new SelectList(_db.Set<Contact>(), "EmployeeId", "EmployeeId", employee.Contact.EmployeeId);

            return View(employee);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var emp = _db.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var emp = _db.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(emp);
            _db.SaveChanges();
            TempData["success"] = "Uspješno brisanje zaposlenika!";
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _db.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
