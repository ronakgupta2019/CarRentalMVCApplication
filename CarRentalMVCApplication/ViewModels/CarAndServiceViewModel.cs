using CarRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalMVCApplication.ViewModels
{
    public class CarAndServiceViewModel
    {
        public Car Car { get; set; }

      //  public Customer customer { get; set; }
      public ApplicationUser User { get; set; }

        public Service Service { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public IEnumerable<ServiceType> ServiceType { get; set; }
    }
}