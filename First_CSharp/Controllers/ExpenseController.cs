using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_CSharp.Data;
using First_CSharp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using First_CSharp.Models.ViewModels;

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

            foreach (var obj in ExpenseList) 
            {
                obj.ExpenseCategory = _db.ExpenseCategories.FirstOrDefault(u => u.Id == obj.FKID);
            }

            return View(ExpenseList);
        }

        //Get Action
        public IActionResult Create()
        {

            //IEnumerable<SelectListItem> DropDownList = _db.ExpenseCategories.Select(i => new SelectListItem()
            //{
            //    Text = i.CategoryName,
            //    Value = i.Id.ToString(),
            //});

            //ViewBag.DropDownList = DropDownList;

            ExpenseVM Expenseview = new ExpenseVM() 
            {
                Expense = new Expense(),
                DropDownList = _db.ExpenseCategories.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.Id.ToString(),
                })
            };

            return View(Expenseview);
        }

        //POST Action
        [HttpPost]
        public IActionResult Create(ExpenseVM newexpense)
        {

            if (ModelState.IsValid) 
            {
                _db.Add(newexpense.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newexpense);
            
        }

        //POST Action
        [HttpPost]
        public IActionResult PostDelete(int? Id)
        {
            var obj = _db.Expenses.Find(Id);

            if (obj == null) 
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //GET Action
        
        public IActionResult Delete(int? Id)
        {
            if(Id == 0 || Id == null) 
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(Id);

            if (obj == null) 
            {
                return NotFound();
            }

            return View(obj);

        }


        public IActionResult Update(int? Id)
        {

            ExpenseVM Expenseview = new ExpenseVM()
            {
                Expense = new Expense(),
                DropDownList = _db.ExpenseCategories.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.Id.ToString(),
                })
            };

            if (Id == 0 || Id == null)
            {
                return NotFound();
            }

            Expenseview.Expense = _db.Expenses.Find(Id);


            if (Expenseview.Expense == null)
            {
                return NotFound();
            }



            return View(Expenseview);

        }

        //POST Action
        [HttpPost]
        public IActionResult PostUpdate(ExpenseVM newexpense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(newexpense.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newexpense);

        }
    }
}
