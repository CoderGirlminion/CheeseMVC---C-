using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();
            return View(cheeses);
        }

        //displays the Add form
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }
        
        [HttpPost]
        //handles the (Add) form submission
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            Cheese newCheese = new Cheese
            {
                Name = addCheeseViewModel.Name,
                Description = addCheeseViewModel.Description
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
