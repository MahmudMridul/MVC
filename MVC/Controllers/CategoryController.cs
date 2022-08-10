using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _database;
        public CategoryController(ApplicationDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _database.Categories;
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //for built in security
        public IActionResult Create(Category category)
        {
            _database.Categories.Add(category);
            _database.SaveChanges(); 
            return RedirectToAction("Index");
        }
    }
}
