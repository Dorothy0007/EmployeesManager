using EmployeesManager.DAL;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(emp);
                _db.SaveChanges();
                TempData["success"] = "Uspješno dodavanje novog zaposlenika!";
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Employee emp)
        {
            if (id != emp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Employees.Update(emp);
                _db.SaveChanges();
                TempData["success"] = "Uspješno ažuriranje zaposlenika!";
                return RedirectToAction("Index");
            }
            return View(emp);
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
    }
}
