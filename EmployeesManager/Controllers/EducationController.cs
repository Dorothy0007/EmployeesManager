using EmployeesManager.DAL;
using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesManager.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationsRepository _context;
        public EducationController(IEducationsRepository context)
        {
            _context = context;
        }

        // GET: EducationController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        // GET: EducationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EducationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje nove edukacije!";
                return RedirectToAction("Index");
            }
            return View(education);
        }

        // GET: EducationController/Edit/5
        public ActionResult Edit(int id)
        {
            var education = _context.GetById(id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Update(education);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje edukacije!";
                return RedirectToAction("Index");
            }
            return View(education);
        }

        // GET: EducationController/Delete/5
        public ActionResult Delete(int id)
        {
            var education = _context.GetById(id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: EducationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var education = _context.GetById(id);

            if (education == null)
            {
                return NotFound();
            }

            _context.Remove(education);
            _context.Save();
            TempData["success"] = "Uspješno brisanje edukacije!";
            return RedirectToAction("Index");
        }
    }
}
