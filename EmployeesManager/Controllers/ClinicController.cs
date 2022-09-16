using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles ="Admin")]
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
        public IActionResult Create([Bind("NameShort,NameLong,HeadClinic,Location")] Clinic clinic)
        {
            if(ModelState.IsValid)
            {
                _context.Add(clinic);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje nove klinike!";
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: ClinicController/Edit/5
        public IActionResult Edit(int? id)
        {
            //var clinic = _context.GetById(id);

            if (id == null)
            {
                return NotFound();
            }

            var clinic = _context.GetById((int)id);

            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // POST: ClinicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ClinicId,NameShort,NameLong,HeadClinic,Location")] Clinic clinic)
        {
            if(id != clinic.ClinicId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(clinic);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje klinike!";
                return RedirectToAction("Index");
            }
            catch { }
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
