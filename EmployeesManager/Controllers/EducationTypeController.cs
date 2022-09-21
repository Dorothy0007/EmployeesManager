using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EducationTypeController : Controller
    {
        private readonly IEducationTypeRepository _context;
        public EducationTypeController(IEducationTypeRepository context)
        {
            _context = context;
        }

        // GET: EducationTypeController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var educationTypes = from t in _context.GetAll()
                                      select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                educationTypes = educationTypes.Where(t => (t.EducationTypeName.ToLower()).Contains(searchString));
            }

            return View(educationTypes.ToList());
        }

        // GET: EducationTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EducationTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EducationTypeName")] EducationType educationType)
        {
            if(ModelState.IsValid)
            {
                _context.Add(educationType);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje novog tipa edukacije!";
                return RedirectToAction("Index");
            }
            return View(educationType);
        }

        // GET: EducationTypeController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationType = _context.GetById((int)id);

            if (educationType == null)
            {
                return NotFound();
            }

            return View(educationType);
        }

        // POST: EducationTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EducationType educationType)
        {
            if (id != educationType.EducationTypeId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(educationType);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje vrste edukacije!";
                return RedirectToAction("Index");
            }
            catch { }
            return View(educationType);
        }

        // GET: EducationTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var educationType = _context.GetById(id);

            if (educationType == null)
            {
                return NotFound();
            }

            return View(educationType);
        }

        // POST: EducationTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var educationType = _context.GetById(id);

            if (educationType == null)
            {
                return NotFound();
            }

            _context.Remove(educationType);
            _context.Save();
            TempData["success"] = "Uspješno brisanje tipa edukacije!";
            return RedirectToAction("Index");
        }
    }
}
