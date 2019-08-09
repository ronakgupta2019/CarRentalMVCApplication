using CarRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalMVCApplication.ViewModels
{
    public class SingleCarViewModel
    {
     public Car Car { get; set; }
        //public Customer Customer { get; set; }
        public ApplicationUser User { get; set; }
    }
}