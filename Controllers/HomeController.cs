using Microsoft.AspNetCore.Http;
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


            //string chosenteam = repo.Teams.Where()
            ViewBag.Teams = repo.Teams.ToList();



            

            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {


            string chosenteam = form["chosenteam"];

            int teamID = Convert.ToInt32(chosenteam);

            // gets  bowlers in a list, sent to the viewbag
            ViewBag.Bowlers = repo.Bowlers.Where(x => x.TeamID == teamID);




            //string chosenteam = repo.Teams.Where()
            ViewBag.Teams = repo.Teams.ToList();


            ViewBag.ChosenTeam = repo.Teams.Where(x => x.TeamID == teamID).FirstOrDefault();
            return View();
        }



        [HttpGet]
        public IActionResult AddEditBowerls(int bowlerid)
        {

            ViewBag.Teams = repo.Teams.ToList();
            // if new bowler
            if (bowlerid == 0)
            {
                return View();
            }

            else
            {
                var bowler = repo.Bowlers.Single(x => x.BowlerID == bowlerid);
                return View(bowler);
            }
           
        }

        [HttpPost]
        public IActionResult AddEditBowerls(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                repo.DoAppointment(bowler);

                return RedirectToAction("Index");
            }
            
            return View(bowler);
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {

            Bowler bowler = repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            repo.Delete(bowler);

            return RedirectToAction("Index");
        }

    }
}
