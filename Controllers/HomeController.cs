using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13MySQLDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13MySQLDB.Controllers
{
    public class HomeController : Controller
    {
 
        private IBowlersRepository repo { get; set; }
        public HomeController(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            ViewBag.Bowlers = repo.Bowlers.ToList();

            return View();
        }

    }
}
