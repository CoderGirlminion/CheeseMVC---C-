using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        //displays the Add form
        public IActionResult Add()
        {
            return View();
        }
        
        [Route("Cheese/Add")]
        [HttpPost]
        //handles the (Add) form submission
        public IActionResult NewCheese(string name, string description = "")
        {
            //uses the default constructor
            //property initialize method that constructs an object
            Cheese newCheese = new Cheese
            {
                Name = name,
                Description = description
            };

            //add new cheese to the list of cheeses, using the above constructor
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

        //removal of cheeses
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach(int cheeseId in cheeseIds)
            {
                //Cheeses.RemoveAll(x => x.CheeseId == cheeseId);
                CheeseData.Remove(cheeseId);
            }
            return Redirect("/");
        }
    
    }
}
