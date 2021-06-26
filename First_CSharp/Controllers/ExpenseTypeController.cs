using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_CSharp.Data;
using First_CSharp.Models;

namespace First_CSharp.Controllers
{
    public class ExpenseTypeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<ExpenseCategory> objList = _db.ExpenseCategories;

            return View(objList);
        }

        //Get Action
        public IActionResult Create() {
            return View();
        }

        //POST Action
        [HttpPost]
        public IActionResult Create(ExpenseCategory newcategory)
        {
            if (ModelState.IsValid) 
            {
                _db.Add(newcategory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newcategory);
            
        }

        //POST Action
        [HttpPost]
        public IActionResult PostDelete(int? Id)
        {
            var obj = _db.ExpenseCategories.Find(Id);

            if (obj == null) 
            {
                return NotFound();
            }

            _db.ExpenseCategories.Remove(obj);
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

            var obj = _db.ExpenseCategories.Find(Id);

            if (obj == null) 
            {
                return NotFound();
            }

            return View(obj);

        }

        //GET action
        public IActionResult Update(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }

            var obj = _db.ExpenseCategories.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST Action
        [HttpPost]
        public IActionResult PostUpdate(ExpenseCategory category)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseCategories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}
