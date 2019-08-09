using CarRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalMVCApplication.ViewModels
{
    public class SearchBarViewModel
    {
       // public Customer Customer { get; set; }
        //public IEnumerable<Customer> Customers { get; set; }
        public int? CheckInteger { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}