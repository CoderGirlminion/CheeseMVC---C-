using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //static - is available to any code within this class
        //instance variable or property of a class is capitalized
        //local variable is lower case
        //a list of cheeses that belong to the controller so that you can use across different controller methods
        static private List<String> Cheeses = new List<String>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;

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
        public IActionResult NewCheese(string name)
        {
            //add new cheese to the list of cheeses
            Cheeses.Add(name);
            return Redirect("/Cheese");

        }
    
    }
}
