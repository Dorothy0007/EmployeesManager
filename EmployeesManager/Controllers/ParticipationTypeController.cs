using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ParticipationTypeController : Controller
    {
        private readonly IParticipationTypeRepository _context;
        public ParticipationTypeController(IParticipationTypeRepository context)
        {
            _context = context;
        }

        // GET: ParticipationTypeController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var participationTypes = from t in _context.GetAll()
                                 select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                participationTypes = participationTypes.Where(t => (t.ParticipationTypeName.ToLower()).Contains(searchString));
            }

            return View(participationTypes.ToList());
        }

        // GET: ParticipationTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipationTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipationTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ParticipationTypeName")] ParticipationType participationType)
        {
            if(ModelState.IsValid)
            {
                _context.Add(participationType);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje nove vrste sudjelovanja!";
                return RedirectToAction("Index");
            }
            
            return View(participationType);
        }

        // GET: ParticipationTypeController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participationType = _context.GetById((int)id);

            if (participationType == null)
            {
                return NotFound();
            }

            return View(participationType);
        }

        // POST: ParticipationTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ParticipationType participationType)
        {
            if (id != participationType.ParticipationTypeId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(participationType);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje vrste sudjelovanja!";
                return RedirectToAction("Index");
            }
            catch { }
            return View(participationType);
        }

        // GET: ParticipationTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var participationType = _context.GetById(id);

            if (participationType == null)
            {
                return NotFound();
            }

            return View(participationType);
        }

        // POST: ParticipationTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var participationType = _context.GetById(id);

            if (participationType == null)
            {
                return NotFound();
            }

            _context.Remove(participationType);
            _context.Save();
            TempData["success"] = "Uspješno brisanje vrste sudjelovanja!";
            return RedirectToAction("Index");
        }
    }
}
