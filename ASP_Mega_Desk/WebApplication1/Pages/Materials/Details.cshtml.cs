using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Materials
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Models.WebApplication1Context _context;

        public DetailsModel(WebApplication1.Models.WebApplication1Context context)
        {
            _context = context;
        }

        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Material.FirstOrDefaultAsync(m => m.MaterialId == id);

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
