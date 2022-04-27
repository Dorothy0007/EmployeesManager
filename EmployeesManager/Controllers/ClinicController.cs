using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IClinicRepository _context;
        public ClinicController(IClinicRepository context)
        {
            _context = context;
        }

        // GET: ClinicController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        // GET: ClinicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinic);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje nove klinike!";
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: ClinicController/Edit/5
        public ActionResult Edit(int id)
        {
            var clinic = _context.GetById(id);

            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // POST: ClinicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Update(clinic);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje klinike!";
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: EducationController/Delete/5
        public ActionResult Delete(int id)
        {
            var clinic = _context.GetById(id);

            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // POST: ClinicController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var clinic = _context.GetById(id);

            if (clinic == null)
            {
                return NotFound();
            }

            _context.Remove(clinic);
            _context.Save();
            TempData["success"] = "Uspješno brisanje klinike!";
            return RedirectToAction("Index");
        }
    }
}
