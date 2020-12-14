using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.RazorPages.Data;
using EmployeeManager.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager.RazorPages.Pages.EmployeeManager
{
    public class ListModel : PageModel
    {

        private readonly AppDbContext _db = null;
        public List<Employee> Employees { get; set; }

        public ListModel(AppDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
            Employees = (from e in _db.Employees orderby e.EmployeeID select e)
                .ToList();
        }
    }
}
