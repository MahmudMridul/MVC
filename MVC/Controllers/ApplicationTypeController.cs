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
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationTypes = _database.ApplicationTypes;
            return View(applicationTypes);
        }

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
    }
}
