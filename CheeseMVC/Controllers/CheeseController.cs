﻿using System;
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
        //static - is available to any code within this class
        //instance variable or property of a class is capitalized
        //local variable is lower case
        static private List<Cheese> Cheeses = new List<Cheese>();
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
        public IActionResult NewCheese(string name, string description = "")
        {
            //add new cheese to the list of cheeses
            //uses the constructor with parameters
            Cheeses.Add(new Cheese(name, description));


            //uses the default constructor
            //property initialize method that constructs an object
            Cheese newCheese = new Cheese
            {
                Name = name,
                Description = description
            };

            //uses the default constructor
            //an empty cheese object that sets the properties one at a time
            /*
             Cheese newCheese = new Cheese();
               newCheese.Description = description;
               newCheese.Name = name;
            */


            return Redirect("/Cheese");

        }
    
    }
}
