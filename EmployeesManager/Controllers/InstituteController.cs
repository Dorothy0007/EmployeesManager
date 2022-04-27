using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    public class InstituteController : Controller
    {
        private readonly IInstituteRepository _context;
        public InstituteController(IInstituteRepository context)
        {
            _context = context;
        }

        // GET: InstituteController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        // GET: InstituteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InstituteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstituteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Institute institute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institute);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje novog Zavoda!";
                return RedirectToAction("Index");
            }
            return View(institute);
        }

        // GET: InstituteController/Edit/5
        public ActionResult Edit(int id)
        {
            var institute = _context.GetById(id);

            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // POST: InstituteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Institute institute)
        {
            if (ModelState.IsValid)
            {
                _context.Update(institute);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje Zavoda!";
                return RedirectToAction("Index");
            }
            return View(institute);
        }

        // GET: InstituteController/Delete/5
        public ActionResult Delete(int id)
        {
            var institute = _context.GetById(id);

            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // POST: InstituteController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var institute = _context.GetById(id);

            if (institute == null)
            {
                return NotFound();
            }

            _context.Remove(institute);
            _context.Save();
            TempData["success"] = "Uspješno brisanje Zavoda!";
            return RedirectToAction("Index");
        }
    }
}
