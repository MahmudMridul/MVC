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

        //[HttpPost]
        //[ValidateAntiForgeryToken] //for built in security
        //public IActionResult Create(Category category)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _database.Categories.Add(category);
        //        _database.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}

        //using client side validation so commented server side validation 
        //client side validation is in create page 

        [HttpPost]
        [ValidateAntiForgeryToken] //for built in security
        public IActionResult Create(Category category)
        {
            
            _database.Categories.Add(category);
            _database.SaveChanges();
            return RedirectToAction("Index");
            
        }

        
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Category category = _database.Categories.Find(id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            _database.Categories.Update(category);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Category category = _database.Categories.Find(id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Category category = _database.Categories.Find(id);

            if(category == null)
            {
                return NotFound();
            }

            _database.Categories.Remove(category);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
