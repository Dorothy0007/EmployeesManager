using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _context;
        public DepartmentController(IDepartmentRepository context)
        {
            _context = context;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var departments = from d in _context.GetAll()
                          select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(d => (d.NameLong.ToLower()).Contains(searchString) || (d.NameShort.ToLower()).Contains(searchString));
            }

            return View(departments.ToList());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try{
                _context.Add(department);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje novog odjela!";
                return RedirectToAction("Index");
                }
            catch { }
            return View(department);
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var department = _context.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Update(department);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje odjela!";
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var department = _context.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var department = _context.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            _context.Remove(department);
            _context.Save();
            TempData["success"] = "Uspješno brisanje odjela!";
            return RedirectToAction("Index");
        }
    }
}
