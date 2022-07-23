﻿using EmployeesManager.DAL;
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
        private readonly IEmployeesRepository _contextEmployee;
        public EducationController(IEducationsRepository context, IEmployeesRepository contextEmployee)
        {
            _context = context;
            _contextEmployee = contextEmployee;
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
            ViewBag.EducationCategory = Enum.GetNames(typeof(EducationCategory)).ToArray();
            ViewBag.EducationType = Enum.GetNames(typeof(EducationType)).ToArray();
            ViewBag.ParticipationType = Enum.GetNames(typeof(ParticipationType)).ToArray();
            ViewBag.Employee = _contextEmployee.GetAll();
            return View();
        }

        // POST: EducationController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Education education, string[] Employees)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var n in Employees)
        //        {
        //            var employee = _contextEmployee.GetById(Convert.ToInt32(n));
        //            education.Employees.Add(employee);
        //        }
        //        _context.Add(education);
        //        _context.Save();
        //        TempData["success"] = "Uspješno dodavanje nove edukacije!";
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Employee = _contextEmployee.GetAll();
        //    ViewBag.EducationCategory = Enum.GetNames(typeof(EducationCategory)).ToArray();
        //    ViewBag.EducationType = Enum.GetNames(typeof(EducationType)).ToArray();
        //    ViewBag.ParticipationType = Enum.GetNames(typeof(ParticipationType)).ToArray();

        //    return View(education);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Education education, string[] Employees)
        {
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
            ViewBag.EducationCategory = Enum.GetNames(typeof(EducationCategory)).ToArray();
            ViewBag.EducationType = Enum.GetNames(typeof(EducationType)).ToArray();
            ViewBag.ParticipationType = Enum.GetNames(typeof(ParticipationType)).ToArray();

            return View(education);
        }

        // GET: EducationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Employee = _contextEmployee.GetAll();
            ViewBag.EducationCategory = Enum.GetNames(typeof(EducationCategory)).ToArray();
            ViewBag.EducationType = Enum.GetNames(typeof(EducationType)).ToArray();
            ViewBag.ParticipationType = Enum.GetNames(typeof(ParticipationType)).ToArray();

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
            ViewBag.EducationCategory = Enum.GetNames(typeof(EducationCategory)).ToArray();
            ViewBag.EducationType = Enum.GetNames(typeof(EducationType)).ToArray();
            ViewBag.ParticipationType = Enum.GetNames(typeof(ParticipationType)).ToArray();
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
