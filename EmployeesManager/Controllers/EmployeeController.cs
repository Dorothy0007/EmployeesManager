﻿using EmployeesManager.DAL;
using EmployeesManager.Model;
using EmployeesManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeesManager.Web.Controllers
{
    public class EmployeeController : Controller
    {

        //private readonly EmployeesManagerDbContext _db;

        //public EmployeeController(EmployeesManagerDbContext db)
        //{
        //    _db = db;
        //}

        private readonly IEmployeesRepository _context;
        public EmployeeController(IEmployeesRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //IEnumerable<Employee> employeeList = _db.Employees;
            //return View(employeeList);
            return View(_context.GetAll().ToList());
        }

        // GET
        public IActionResult Create()
        {
          return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {

                //_db.Employees.Add(GetEmployee(new Employee(), emp));
                //_db.SaveChanges();
                _context.Add(employee);
                _context.Save();
                TempData["success"] = "Uspješno dodavanje novog zaposlenika!";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //GET
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employee = _context.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employee);
                _context.Save();
                TempData["success"] = "Uspješno ažuriranje zaposlenika!";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET
        public IActionResult Delete(int id)
        {
            var employee = _context.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var employee = _context.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Remove(employee);
            _context.Save();
            TempData["success"] = "Uspješno brisanje zaposlenika!";
            return RedirectToAction("Index");
        }

        // GET
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }

        //        var emp = _db.Employees.Where(x => x.EmployeeId == id).Select(x => new EmployeeViewModel()
        //        {
        //            EmployeeId = x.EmployeeId,
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            OIB = x.OIB,
        //            MBO = x.MBO,
        //            BirthDate = x.BirthDate,
        //            Street = x.Street,
        //            StreetNumber = x.StreetNumber,
        //            PostalCode = x.PostalCode,
        //            City = x.City,
        //            Country = x.Country,
        //            PrivateEmail = x.PrivateEmail,
        //            PrivateMobilePhone = x.PrivateMobilePhone,
        //            BusinessEmail = x.BusinessEmail,
        //            BusinessMobilePhone = x.BusinessMobilePhone,
        //            BusinessTelephone = x.BusinessTelephone,
        //            Active = x.Active

        //            //Healthcares = x.Healthcares.ToList()

        //        }).FirstOrDefault();

        //        //_db.Entry(emp).Collection(x => x.Healthcares).Load();

        //        if (emp == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(emp);
        //    }

        //    //POST
        //   [HttpPost]
        //   [ValidateAntiForgeryToken]
        //    public IActionResult Edit(int? id, EmployeeViewModel emp)
        //    {
        //        var exemp = _db.Employees.Find(id);

        //        if (exemp == null)
        //        {
        //            return NotFound();
        //        }

        //        //_db.Entry(exemp).Reference(x => x.Address).Load();
        //        //_db.Entry(exemp).Reference(x => x.Contact).Load();

        //        if (ModelState.IsValid)
        //        {
        //            _db.Employees.Update(GetEmployee(exemp, emp));
        //            _db.SaveChanges();
        //            TempData["success"] = "Uspješno ažuriranje zaposlenika!";
        //            return RedirectToAction("Index");
        //        }
        //        return View(emp);
        //    }

        //    // GET
        //    public IActionResult Delete(int? id)
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }

        //        var emp = _db.Employees.Find(id);

        //        if (emp == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(emp);
        //    }

        //    // POST
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult DeletePost(int? id)
        //    {
        //        var emp = _db.Employees.Find(id);

        //        if (emp == null)
        //        {
        //            return NotFound();
        //        }

        //        _db.Employees.Remove(emp);
        //        _db.SaveChanges();
        //        TempData["success"] = "Uspješno brisanje zaposlenika!";
        //        return RedirectToAction("Index");
        //    }

        //    //private bool EmployeeExists(int id)
        //    //{
        //    //    return _db.Employees.Any(e => e.EmployeeId == id);
        //    //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateOrEdit(EmployeeViewModel emp)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        //if (emp.EmployeeId == 0)
        //        //{
        //        //    foreach (Healthcare healthcare in emp.Healthcares)
        //        //    {
        //        //        if(healthcare.HealthcareName.ToString() == null)
        //        //        {
        //        //            emp.Healthcares.Remove(healthcare);
        //        //        }
        //        //    }
        //        //    _db.Employees.Add(GetEmployee(new Employee(), emp));
        //        //}

        //        if (emp.EmployeeId == 0)
        //            _db.Employees.Add(GetEmployee(new Employee(), emp));

        //        else
        //        {
        //            var exemp = _db.Employees.Find(emp.EmployeeId);

        //            if (exemp == null)
        //            {
        //                return NotFound();
        //            }
        //            _db.Entry(exemp).Reference(x => x.Address).Load();
        //            _db.Entry(exemp).Reference(x => x.Contact).Load();
        //            _db.Entry(exemp).Collection(x => x.Healthcares).Load();
        //            _db.Employees.Update(GetEmployee(exemp, emp));
        //        }

        //        _db.SaveChanges();
        //        TempData["success"] = emp.EmployeeId == 0 ? "Uspješno dodavanje novog zaposlenika!" : "Uspješno ažuriranje zaposlenika!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(emp);
        //}

        //    private Employee GetEmployee(Employee newEmp, EmployeeViewModel emp)
        //    {
        //        newEmp.FirstName = emp.FirstName;
        //        newEmp.LastName = emp.LastName;
        //        newEmp.OIB = emp.OIB;
        //        newEmp.MBO = emp.MBO;
        //        newEmp.BirthDate = emp.BirthDate;
        //        newEmp.Active = emp.Active;

        //        //Address adr = new Address();
        //        //adr.Street = emp.Street;
        //        //adr.StreetNumber = emp.StreetNumber;
        //        //adr.Country = emp.Country;
        //        //adr.PostalCode = emp.PostalCode;
        //        //adr.City = emp.City;

        //        //newEmp.Address = adr;

        //        //Contact cnt = new Contact();
        //        //cnt.BusinessEmail = emp.BusinessEmail;
        //        //cnt.BusinessTelephone = emp.BusinessTelephone;
        //        //cnt.BusinessMobilePhone = emp.BusinessMobilePhone;
        //        //cnt.PrivateMobilePhone = emp.PrivateMobilePhone;
        //        //cnt.PrivateEmail = emp.PrivateEmail;

        //        //newEmp.Contact = cnt;

        //        //Healthcare hlt = new Healthcare();
        //        //hlt.HealthcareName = emp.HealthcareName;
        //        //hlt.ValidUntil = emp.ValidUntil;
        //        //hlt.Remark = emp.Remark;

        //        //newEmp.Healthcares.Add(hlt);

        //        return newEmp;
        //    }
    }
}
