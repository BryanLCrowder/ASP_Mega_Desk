using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplication1Context>>()))
            {
                // Look for any movies.
                if (context.Material.Any())
                {
                    return;   // DB has been seeded
                }

                context.Material.AddRange(
                    new Material
                    {
                        MaterialType = "Oak",
                        Price = 200
                    },
                    new Material
                    {
                        MaterialType = "Laminate",
                        Price = 100
                    },
                     new Material
                     {
                         MaterialType = "Pine",
                         Price = 50
                     },
                     new Material
                     {
                         MaterialType = "Veneer",
                         Price = 125
                     },
                     new Material
                     {
                         MaterialType = "Oak",
                         Price = 200
                     }
                );

                context.Delivery.AddRange(
                    new Delivery
                    {
                        RushOrderDay = "3 Day",
                        Days = 3
                    },
                     new Delivery
                     {
                         RushOrderDay = "5 Day",
                         Days = 5
                     },
                    new Delivery
                    {
                        RushOrderDay = "7 Day",
                        Days = 7
                    },
                     new Delivery
                     {
                         RushOrderDay = "14 Day (Normal Shipping)",
                         Days = 14
                     }
                    );
                
                  
                context.SaveChanges();
            }
        }
    }
}