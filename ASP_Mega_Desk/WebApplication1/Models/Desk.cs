using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models
{
    public class Desk
    {
        public int DeskID { get; set; }
        [Range(24, 96)]
        public int Width { get; set; }

        [Range(12, 48)]
        public int Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        [Range(0, 7)]
        public int NumDrawers { get; set; }

        [Display(Name = "Material")]
        public int MaterialID { get; set; }
        public Material Material { get; set; }


        public decimal surfaceArea()
        {
            return Width * Depth;
        }



    }
}