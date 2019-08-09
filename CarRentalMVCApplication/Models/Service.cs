using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalMVCApplication.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter the number of miles travelled")]
        public double Miles { get; set; }
        [Required(ErrorMessage ="Price is needed")]
        public double Price { get; set; }

        public string Details { get; set; }


        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }


        public Car car { get; set; }
        public int CarId { get; set; }



        public ServiceType ServiceType { get; set; }
        [Display(Name="ServiceType")]
        public int ServiceTypeId { get; set; }


               


        

    }
}