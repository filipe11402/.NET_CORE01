using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_CSharp.Data;
using First_CSharp.Models;

namespace First_CSharp.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<Expense> ExpenseList = _db.Expenses;

            return View(ExpenseList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense newexpense)
        {
            _db.Add(newexpense);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
