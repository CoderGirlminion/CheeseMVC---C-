using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name="Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a description of the cheese")]
        public string Description { get; set; }

        //stores the CheeseType that the user has selected
        public CheeseType Type { get; set; }

        //a select element that allows the user all of the options to choose from
        public List<SelectListItem> CheeseTypes { get; set; }

        //select list items that will represent the different cheesetypes via a constructor
        //constructor
        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();

            //<option value="0">Hard</option
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }
    }
}
