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
 

        // creates repo
        private IBowlersRepository repo { get; set; }


        // constructor
        public HomeController(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {

            // gets all bowlers in a list, sent to the viewbag
            ViewBag.Bowlers = repo.Bowlers.ToList();

            return View();
        }

        public IActionResult AddEditBowerls()
        {
            return View();
        }

    }
}
