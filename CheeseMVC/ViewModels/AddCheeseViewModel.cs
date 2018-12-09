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
    }
}
