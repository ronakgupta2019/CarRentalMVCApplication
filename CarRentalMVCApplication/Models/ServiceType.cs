using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRentalMVCApplication.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ServiceType is Mandatory")]
        [Display(Name = "ServiceType")]

        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets ")]
        public string Name { get; set; }

    }
}