using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        [Display(Name = "Shipping")]
        public string RushOrderDay { get; set; }
        public int Days { get; set; }
    }
}