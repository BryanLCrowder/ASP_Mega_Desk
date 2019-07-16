using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Material
    {
        [Display(Name = "Material")]
        public int MaterialId { get; set; }
        
        public decimal Price { get; set; }
        public string MaterialType { get; set; }
    }
}