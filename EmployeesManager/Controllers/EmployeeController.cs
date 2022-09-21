using ClosedXML.Excel;
using EmployeesManager.DAL;
using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesRepository _context;
        private readonly IHealthCareRepository _healthCare;
        private readonly IEducationsRepository _contextEducation;
        public EmployeeController(IEmployeesRepository context, IHealthCareRepository healthCare, IEducationsRepository education)
        {
            _context = context;
            _healthCare = healthCare;
            _contextEducation = education;
        }

        public IActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var employees = from e in _context.GetAll()
                         select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => (e.FirstName.ToLower()).Contains((searchString).ToLower()) || (e.LastName.ToLower()).Contains((searchString).ToLower()));
            }

            return View(employees.ToList());
        }

        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ViewBag.HealthcareName = Enum.GetNames(typeof(HealthcareName)).ToArray();
            var employee = _context.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public ActionResult DetailsEmployee(int id)
        {
            ViewBag.Educations = _contextEducation.GetAll();

            var employee = _context.GetEmployeeEducations(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View("DetailsEmployee", employee);
        }

        // GET
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.HealthcareName = Enum.GetNames(typeof(HealthcareName)).ToArray();
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Employee employee)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateEmployee(Employee employee, string[] Step)
        {
            _context.Add(employee);
            _context.Save();
            var employees = _context.GetAll().OrderByDescending(x => x.EmployeeId).Take(1).LastOrDefault();
            List<Healthcare> Healthcare = new List<Healthcare>();
            foreach (var n in Step)
            {
                var data = n.Split(',');
                Healthcare.Add(new Healthcare
                {
                    HealthcareName = data[0],
                    ValidUntil = Convert.ToDateTime(data[1]),
                    Remark = data[2],
                    EmployeeId = employees.EmployeeId,
                });
            }
            _healthCare.AddRange(Healthcare);
            _healthCare.Save();
            return Json(true);

        }

        //GET
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ViewBag.HealthcareName = Enum.GetNames(typeof(HealthcareName)).ToArray();
            var employee = _context.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //POST
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditEmployee(Employee employee, string[] Step)
        {
            _context.Update(employee);
            _context.Save();
            var healthCare = _healthCare.GetHealthCare(employee.EmployeeId);
            if (healthCare.Count > 0)
            {
                _healthCare.RemoveRange(healthCare);
                _healthCare.Save();
            }
            List<Healthcare> Healthcare = new List<Healthcare>();
            foreach (var n in Step)
            {
                var data = n.Split(',');
                Healthcare.Add(new Healthcare
                {
                    HealthcareName = data[0],
                    ValidUntil = Convert.ToDateTime(data[1]),
                    Remark = data[2],
                    EmployeeId = employee.EmployeeId,
                });
            }
            _healthCare.AddRange(Healthcare);
            _healthCare.Save();
            return Json(true);
        }

        // GET
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var employee = _context.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int id)
        {
            var employee = _context.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Remove(employee);
            _context.Save();
            TempData["success"] = "Uspješno brisanje zaposlenika!";
            return RedirectToAction("Index");
        }

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateOrEdit(EmployeeViewModel emp)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        //if (emp.EmployeeId == 0)
        //        //{
        //        //    foreach (Healthcare healthcare in emp.Healthcares)
        //        //    {
        //        //        if(healthcare.HealthcareName.ToString() == null)
        //        //        {
        //        //            emp.Healthcares.Remove(healthcare);
        //        //        }
        //        //    }
        //        //    _db.Employees.Add(GetEmployee(new Employee(), emp));
        //        //}

        //        if (emp.EmployeeId == 0)
        //            _db.Employees.Add(GetEmployee(new Employee(), emp));

        //        else
        //        {
        //            var exemp = _db.Employees.Find(emp.EmployeeId);

        //            if (exemp == null)
        //            {
        //                return NotFound();
        //            }
        //            _db.Entry(exemp).Reference(x => x.Address).Load();
        //            _db.Entry(exemp).Reference(x => x.Contact).Load();
        //            _db.Entry(exemp).Collection(x => x.Healthcares).Load();
        //            _db.Employees.Update(GetEmployee(exemp, emp));
        //        }

        //        _db.SaveChanges();
        //        TempData["success"] = emp.EmployeeId == 0 ? "Uspješno dodavanje novog zaposlenika!" : "Uspješno ažuriranje zaposlenika!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(emp);
        //}

        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Ime"),
                                        new DataColumn("Prezime"),
                                        new DataColumn("OIB"),
                                        new DataColumn("MBO"),
                                        new DataColumn("Aktivnost"),
                                        new DataColumn("Datum rođenja"),
                                        new DataColumn("Ulica"),
                                        new DataColumn("Kućni broj") });

            var employees = from employee in this._context.GetAll()
                             select employee;

            foreach (var employee in employees)
            {
                dt.Rows.Add(employee.FirstName, employee.LastName, employee.OIB, employee.MBO, employee.Active, employee.BirthDate, employee.Street, employee.StreetNumber);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
                }
            }
        }

        [HttpPost]
        public IActionResult ExportSingle(int id)
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Ime"),
                                        new DataColumn("Prezime"),
                                        new DataColumn("OIB"),
                                        new DataColumn("MBO"),
                                        new DataColumn("Aktivnost"),
                                        new DataColumn("Datum rođenja"),
                                        new DataColumn("Ulica"),
                                        new DataColumn("Kućni broj") });

            Employee employee = _context.GetById(id);

            //foreach (var education in educations)
            //{
            dt.Rows.Add(employee.FirstName, employee.LastName, employee.OIB, employee.MBO, employee.Active, employee.BirthDate, employee.Street, employee.StreetNumber);
            //}

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", employee.FirstName+" "+employee.LastName+".xlsx");
                }
            }
        }

    }
}
