using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalMVCApplication.Models
{
    public class Car
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Vin is Mandatory")]
        [Display(Name = "VIN")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers")]

        public string VIN { get; set; }
        [Required(ErrorMessage = "Make is Mandatory")]
        [Display(Name = "MAKE")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets ")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Model is Mandatory")]
        [Display(Name = "MODEL")]
       
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets ")]
        public string Model { get; set; }
        public string Style { get; set; }
        [Required(ErrorMessage = "Year is Mandatory")]
        [Display(Name = "Year")]
      
        public int Year { get; set; }
        [Required(ErrorMessage = "Miles is Mandatory")]
        [Display(Name = "MILES")]
       
        public double Miles { get; set; }
        public string Color { get; set; }


        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
    