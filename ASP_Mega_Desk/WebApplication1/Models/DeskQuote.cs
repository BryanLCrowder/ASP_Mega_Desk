using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class DeskQuote
    {
        const decimal BASE_PRICE = 200;

        [Display(Name = "Desk Quote")]
        public int DeskQuoteID { get; set; }
        //link desk

        [Display(Name = "Desk ID")]
        public int DeskID { get; set; }
        public Desk Desk { get; set; }
        // link delivery 

        [Display(Name = "Delivery ID")]
        public int DeliveryID { get; set; }
        public Delivery Delivery { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Shipping Cost")]
        public decimal ShippingCost { get; set; }

        [Display(Name = "Desk Price")]
        public decimal DeskPrice { get; set; }

    

        public DeskQuote()
        {

        }
       
        public decimal calcshippingCost(decimal pvRushDays, decimal pvArea)
        {

            decimal shippingPrice;


            if (pvRushDays == 3)
            {
                if (pvArea < 1000)
                {
                    shippingPrice = 60;
                }
                else if (pvArea < 2001)
                {
                    shippingPrice = 70;
                }
                else
                {
                    shippingPrice = 80;
                }
            }
            else if (pvRushDays == 5)
            {
                if (pvArea < 1000)
                {
                    shippingPrice = 40;
                }
                else if (pvArea < 2001)
                {
                    shippingPrice = 45;
                }
                else
                {
                    shippingPrice = 60;
                }
            }
            else
            {
                if (pvArea < 1000)
                {
                    shippingPrice = 60;
                }
                else if (pvArea < 2001)
                {
                    shippingPrice = 70;
                }
                else
                {
                    shippingPrice = 80;
                }
            }
            return shippingPrice;

        }


        //
        // Calculate the cost of the desk
        //
        public decimal calcDeskPrice(decimal pvMaterialCost, decimal pvArea, decimal pvShippingCost)
        {
            if (pvArea < 1000)
                return BASE_PRICE + pvShippingCost + pvMaterialCost;
            else
                return BASE_PRICE + pvShippingCost + pvMaterialCost + pvArea;


        }

    }

}