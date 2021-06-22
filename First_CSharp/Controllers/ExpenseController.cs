﻿using Microsoft.AspNetCore.Mvc;
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

        //Get Action
        public IActionResult Create() {
            return View();
        }

        //POST Action
        [HttpPost]
        public IActionResult Create(Expense newexpense)
        {
            if (ModelState.IsValid) 
            {
                _db.Add(newexpense);
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
            if (Id == 0 || Id == null)
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

        //POST Action
        [HttpPost]
        public IActionResult PostUpdate(Expense newexpense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(newexpense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newexpense);

        }
    }
}
