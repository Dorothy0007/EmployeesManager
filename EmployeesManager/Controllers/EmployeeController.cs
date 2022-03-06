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
        [HttpGet]
        public IActionResult Create()
        {
            //Employee employee = new Employee();
            //employee.Address = new Address();
            //employee.Contact = new Contact();
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            Employee emp = new Employee();

            emp.EmployeeId = employee.EmployeeId;
            emp.MBO = employee.MBO;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.OIB = employee.OIB;
            emp.Active = employee.Active;
            emp.BirthDate = employee.BirthDate;

            Contact contact = new Contact();
            contact.BusinessTelephone = employee.Contact.BusinessTelephone;
            contact.BusinessEmail = employee.Contact.BusinessEmail;
            contact.PrivateEmail = employee.Contact.PrivateEmail;
            contact.PrivateMobilePhone = employee.Contact.PrivateMobilePhone;
            contact.BusinessMobilePhone = employee.Contact.BusinessMobilePhone;

            Address address = new Address();
            address.Street = employee.Address.Street;
            address.StreetNumber = employee.Address.StreetNumber;
            address.Country = employee.Address.Country;
            address.City = employee.Address.City;
            address.PostalCode = employee.Address.PostalCode;

            emp.Contact = contact;
            emp.Address = address;

            //if (ModelState.IsValid)
            //{
            //    _db.Employees.Add(emp);
            //    _db.SaveChanges();
            //    TempData["success"] = "Uspješno dodavanje novog zaposlenika!";
            //    return RedirectToAction("Index");
            //}

            _db.Employees.Add(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");

            //return View(employee);
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
            if (id != emp.EmployeeId)
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
