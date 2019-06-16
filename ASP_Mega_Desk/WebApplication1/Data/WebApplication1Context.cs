using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Desk> Desk { get; set; }

        public DbSet<WebApplication1.Models.Link> Link { get; set; }

        public DbSet<WebApplication1.Models.DeskQuote> DeskQuote { get; set; }
    }
}
