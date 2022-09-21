using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EducationCategoryController : Controller
    {
        private readonly IEducationCategoryRepository _context;
        public EducationCategoryController(IEducationCategoryRepository context)
        {
            _context = context;
        }

        // GET: EducationCategoryController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var educationCategories = from c in _context.GetAll()
                             select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                educationCategories = educationCategories.Where(c => (c.CategoryName.ToLower()).Contains(searchString));
            }

            return View(educationCategories.ToList());
        }

        // GET: EducationCategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EducationCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName")] EducationCategory educationCategory)
        {
            if(ModelState.IsValid)
            {
                _context.Add(educationCategory);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje nove kategorije!";
                return RedirectToAction("Index");
            }

            return View(educationCategory);
        }

        // GET: EducationCategoryController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCategory = _context.GetById((int)id);

            if (educationCategory == null)
            {
                return NotFound();
            }

            return View(educationCategory);
        }

        // POST: EducationCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EducationCategory educationCategory)
        {
            if (id != educationCategory.EducationCategoryId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(educationCategory);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje kategorije!";
                return RedirectToAction("Index");
            }
            catch { }
            return View(educationCategory);
        }

        // GET: EducationCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var educationCategory = _context.GetById(id);

            if (educationCategory == null)
            {
                return NotFound();
            }

            return View(educationCategory);
        }

        // POST: EducationCategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var educationCategory = _context.GetById(id);

            if (educationCategory == null)
            {
                return NotFound();
            }

            _context.Remove(educationCategory);
            _context.Save();
            TempData["success"] = "Uspješno brisanje kategorije!";
            return RedirectToAction("Index");
        }
    }
}
