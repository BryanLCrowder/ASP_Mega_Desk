using System;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DeskQuote
    {
            //Constructor for rushOrder array calculation
            public DeskQuote()
            {
                this.SetRushOrder(getRushOrder());
            }
        public int ID { get; set; }

        private int[,] rushOrder;

        public int[,] GetRushOrder()
        {
            return rushOrder;
        }

        public void SetRushOrder(int[,] value)
        {
            rushOrder = value;
        }
        [Display(Name = "Customers Name")]
        public string CustomersName { get; set; }
        [Display(Name = "Shipping Days")]
        public int ShippingDays { get; set; }
        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }

            public decimal Quote { get; set; }
            public decimal ShippingCost { get; set; }
            public decimal StructureCost { get; set; }
            public decimal SurfaceCost { get; set; }


            public Desk Desk { get; set; }

            public decimal GetQuote()
            {
                Quote = GetShippingCost() + GetStructureCost() + GetSurfaceCost();
                return Quote;
            }


            //**GET CURRENT PRICES BASED ON .txt**//
            public int[,] getRushOrder()
            {

                string[] rushAmount = File.ReadAllLines(@"rushOrderPrices.txt");
                int[,] rushAmountGrid = new int[3, 3];
                int row;
                int column;
                int count = 0;

                for (row = 0; row < 3; row++)
                {
                    for (column = 0; column < 3; column++)
                    {
                        rushAmountGrid[row, column] = int.Parse(rushAmount[count]);
                        count++;
                    }
                }
                return rushAmountGrid;
            }

            public decimal GetShippingCost()
            {
                decimal size = Desk.WidthUpDown * Desk.HeightUpDown;
                switch (ShippingDays)
                {
                    case 3:
                        if (size < 1000)
                            ShippingCost = this.GetRushOrder()[0, 0];
                        if (size > 1000 && size < 2000)
                            ShippingCost = this.GetRushOrder()[0, 1];
                        else if (size > 2000)
                            ShippingCost = this.GetRushOrder()[0, 2];
                        break;
                    case 5:
                        if (size < 1000)
                            ShippingCost = this.GetRushOrder()[1, 0];
                        if (size > 1000 && size < 2000)
                            ShippingCost = this.GetRushOrder()[1, 1];
                        else if (size > 2000)
                            ShippingCost = this.GetRushOrder()[1, 2];
                        break;
                    case 7:
                        if (size < 1000)
                            ShippingCost = this.GetRushOrder()[2, 0];
                        if (size > 1000 && size < 2000)
                            ShippingCost = this.GetRushOrder()[2, 1];
                        else if (size > 2000)
                            ShippingCost = this.GetRushOrder()[2, 2];
                        break;
                    case 14:
                        ShippingCost = 0;
                        break;
                    default:
                        break;
                }

                return ShippingCost;
            }

            public decimal GetStructureCost()
            {
                StructureCost = (Desk.NumDrawers * 50) + 200;
                return StructureCost;
            }

            public decimal GetSurfaceCost()
            {
                decimal size = Desk.WidthUpDown * Desk.HeightUpDown;

                switch (Desk.Material)
                {
                    case Desk.DeskMaterial.Rosewood:
                        SurfaceCost = 300;
                        break;
                    case Desk.DeskMaterial.Laminate:
                        SurfaceCost = 100;
                        break;
                    case Desk.DeskMaterial.Veneer:
                        SurfaceCost = 125;
                        break;
                    case Desk.DeskMaterial.Oak:
                        SurfaceCost = 200;
                        break;
                    case Desk.DeskMaterial.Pine:
                        SurfaceCost = 50;
                        break;
                    default:
                        break;
                }

                if (size > 1000)
                    SurfaceCost += size;
                else
                    SurfaceCost += 0;

                return SurfaceCost;
            }
        }

    }
