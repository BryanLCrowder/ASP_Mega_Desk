using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Desk
    {
        public int ID { get; set; }
        [Display(Name = "Width")]
        public decimal WidthUpDown { get; set; }
        [Display(Name = "Height")]
        public decimal HeightUpDown { get; set; }
        [Display(Name = "Drawers")]
        public int NumDrawers { get; set; }

        public enum DeskMaterial
        {
            Rosewood,
            Laminate,
            Veneer,
            Oak,
            Pine,
        }

        public DeskMaterial Material { get; set; }
    }
}
