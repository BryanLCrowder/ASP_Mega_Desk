using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DeskQuote
    {

        public int ID { get; set; }
       

        public string CustomerName { get; set; }
        public int ShippingDays { get; set; }
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
        public decimal Quote { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal StructureCost { get; set; }
        public decimal SurfaceCost { get; set; }
        public Desk Desk { get; set; }

    }
}