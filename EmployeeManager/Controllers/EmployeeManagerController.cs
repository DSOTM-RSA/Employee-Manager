using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
    [Authorize(Roles="Manager")]
    public class EmployeeManagerController : Controller
    {

        private AppDbContext _db;
        public EmployeeManagerController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult List()
        {
            List<Employee> model = (from e in _db.Employees
                                    orderby e.EmployeeID
                                    select e).ToList();

            return View(model);
        }


        [HttpGet]
        public IActionResult Insert()
        {
            FillCountries();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Employee model)
        {
            FillCountries();

            if (ModelState.IsValid)
            {
                _db.Employees.Add(model);
                _db.SaveChanges();
                ViewBag.Message = "Employee added successfully";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            FillCountries();
            var model = _db.Employees.Find(id);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee model)
        {
            FillCountries();

            if (ModelState.IsValid)
            {
                _db.Employees.Update(model);
                _db.SaveChanges();
                ViewBag.Message = "Employee updated successfully";
            }

            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var model = _db.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = _db.Employees.Find(id);
            _db.Employees.Remove(model);
            _db.SaveChanges();

            TempData["Message"] = "Employee Deleted Successfully";

            return RedirectToAction("List");
        }


        private void FillCountries()
        {
            List<SelectListItem> listOfCountries = (from c in _db.Employees
                                                    select new SelectListItem()
                                                    {
                                                        Text = c.Country,
                                                        Value = c.Country
                                                    }).Distinct().ToList();

            ViewBag.Countries = listOfCountries;
        }


    }
}
