using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_CSharp.Data;
using First_CSharp.Models;

namespace First_CSharp.Controllers
{
    public class ItemController : Controller
    {
        //using DI(dependency injection)
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<Item> objlist = _db.Items;


            return View(objlist);
        }

        public IActionResult Create() 
        {
            return View();
        }
    }
}
