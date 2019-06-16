using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Desk
    {
        public int ID { get; set; }
        public decimal WidthUpDown { get; set; }
        public decimal HeightUpDown { get; set; }
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
