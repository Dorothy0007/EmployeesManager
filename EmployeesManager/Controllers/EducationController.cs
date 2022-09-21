using EmployeesManager.DAL;
using EmployeesManager.DAL.Interfaces;
using EmployeesManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Data;
using System.Linq;
using ClosedXML.Excel;

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using iTextSharp.tool.xml;

namespace EmployeesManager.Web.Controllers
{

    [Authorize(Roles = "Admin, User")]
    public class EducationController : Controller
    {
        private readonly IEducationsRepository _context;
        private readonly IEmployeesRepository _contextEmployee;
        private readonly IEducationCategoryRepository _contextCategory;
        private readonly IEducationTypeRepository _contextEducationType;
        private readonly IParticipationTypeRepository _contextParticipationType;

        public EducationController(IEducationsRepository context, IEmployeesRepository contextEmployee, IEducationCategoryRepository contextCategory,
                                        IEducationTypeRepository contextEducationType, IParticipationTypeRepository contextParticipationType)
        {
            _context = context;
            _contextEmployee = contextEmployee;
            _contextCategory = contextCategory;
            _contextParticipationType = contextParticipationType;
            _contextEducationType = contextEducationType;
        }

        // GET: EducationController
        public ActionResult Index()
        {
            return View(_context.GetAll().ToList());
        }

        // GET: EducationController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Employee = _contextEmployee.GetAll();
            ViewBag.EducationCategory = _contextCategory.GetAll();
            ViewBag.EducationType = _contextEducationType.GetAll();
            ViewBag.ParticipationType = _contextParticipationType.GetAll();

            var education = _context.GetEducation(id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }
        [HttpGet]
        public ActionResult DetailsEmployee(int id)
        {
            ViewBag.Employee = _contextEmployee.GetAll();
           
            var education = _context.GetEducation(id);

            if (education == null)
            {
                return NotFound();
            }

            return View("DetailsEducation", education);
        }

        // GET: EducationController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.EducationCategory = _contextCategory.GetAll();
            ViewBag.EducationType = _contextEducationType.GetAll();
            ViewBag.ParticipationType = _contextParticipationType.GetAll();
            ViewBag.Employee = _contextEmployee.GetAll();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Education education, string[] Employees)
        {
            //_contextCategory.Add(education.EducationCategory);
            if (ModelState.IsValid)
            {
                foreach (var n in Employees)
                {
                    var employee = _contextEmployee.GetById(Convert.ToInt32(n));
                    education.Employees.Add(employee);
                }
                _context.Add(education);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje nove edukacije!";
                return RedirectToAction("Index");
            }
            ViewBag.Employee = _contextEmployee.GetAll();
            ViewBag.EducationCategory = _contextCategory.GetAll();
            ViewBag.EducationType = _contextEducationType.GetAll();
            ViewBag.ParticipationType = _contextParticipationType.GetAll();

            return View(education);
        }

        // GET: EducationController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Employee = _contextEmployee.GetAll();
            ViewBag.EducationCategory = _contextCategory.GetAll();
            ViewBag.EducationType = _contextEducationType.GetAll();
            ViewBag.ParticipationType = _contextParticipationType.GetAll();

            var education = _context.GetEducation(id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: EducationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Education education, string[] Employees)
        {
            if (ModelState.IsValid)
            {
                var getById = _context.GetById(Convert.ToInt32(education.EducationId));
                _context.Remove(getById);
                _context.Save();
                education.EducationId = 0;
                foreach (var n in Employees)
                {
                    var employee = _contextEmployee.GetById(Convert.ToInt32(n));
                    education.Employees.Add(employee);
                }
                _context.Add(education);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje edukacije!";
                return RedirectToAction("Index");
            }
            ViewBag.Employee = _contextEmployee.GetAll();
            ViewBag.EducationCategory = _contextCategory.GetAll();
            ViewBag.EducationType = _contextEducationType.GetAll();
            ViewBag.ParticipationType = _contextParticipationType.GetAll();
            return View(education);
        }

        // GET: EducationController/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Naziv edukacije"),
                                        new DataColumn("Kategorija edukacije"),
                                        new DataColumn("Vrsta edukacije"),
                                        new DataColumn("Vrsta sudjelovanja") });

            var educations = from education in this._context.GetAll()
                            select education;

            foreach (var education in educations)
            {
                dt.Rows.Add(education.EducationName, education.EducationCategory, education.EducationType, education.ParticipationType);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Educations.xlsx");
                }
            }
        }

        [HttpPost]
        public IActionResult ExportSingle(int id)
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Naziv edukacije"),
                                        new DataColumn("Kategorija edukacije"),
                                        new DataColumn("Vrsta edukacije"),
                                        new DataColumn("Vrsta sudjelovanja") });

            var education = _context.GetById(id);

            //foreach (var education in educations)
            //{
                dt.Rows.Add(education.EducationName, education.EducationCategory, education.EducationType, education.ParticipationType);
            //}

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Education.xlsx");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var educations = from e in _context.GetAll()
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                educations = educations.Where(e => (e.EducationName.ToLower()).Contains(searchString));
            }

            return View(educations.ToList());
        }
    }
}
