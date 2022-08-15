using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ApplicationTypeController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationTypes = _database.ApplicationTypes;
            return View(applicationTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            _database.ApplicationTypes.Add(applicationType);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            ApplicationType applicationType = _database.ApplicationTypes.Find(id);

            if(applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            _database.ApplicationTypes.Update(applicationType);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            ApplicationType applicationType = _database.ApplicationTypes.Find(id);

            if(applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ApplicationType applicationType)
        {
            _database.ApplicationTypes.Remove(applicationType);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
