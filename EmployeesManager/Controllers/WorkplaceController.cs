using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WorkplaceController : Controller
    {
        private readonly IWorkplaceRepository _context;
        public WorkplaceController(IWorkplaceRepository context)
        {
            _context = context;
        }

        // GET: WorkplaceController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        // GET: WorkplaceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkplaceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkplaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workplace workplace)
        {
            try
            {
                _context.Add(workplace);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje novog radilišta!";
                return RedirectToAction("Index");
            }
            catch { }
            return View(workplace);
        }

        // GET: WorkplaceController/Edit/5
        public ActionResult Edit(int id)
        {
            var workplace = _context.GetById(id);

            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // POST: WorkplaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                _context.Update(workplace);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje radilišta!";
                return RedirectToAction("Index");
            }
            return View(workplace);
        }

        // GET: WorkplaceController/Delete/5
        public ActionResult Delete(int id)
        {
            var workplace = _context.GetById(id);

            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // POST: WorkplaceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var workplace = _context.GetById(id);

            if (workplace == null)
            {
                return NotFound();
            }

            _context.Remove(workplace);
            _context.Save();
            TempData["success"] = "Uspješno brisanje radilišta!";
            return RedirectToAction("Index");
        }
    }
}
