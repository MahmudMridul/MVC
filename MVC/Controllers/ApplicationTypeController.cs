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
    }
}
