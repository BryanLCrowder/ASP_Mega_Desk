using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Deliveries
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Models.WebApplication1Context _context;

        public DeleteModel(WebApplication1.Models.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Delivery Delivery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Delivery = await _context.Delivery.FirstOrDefaultAsync(m => m.DeliveryID == id);

            if (Delivery == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Delivery = await _context.Delivery.FindAsync(id);

            if (Delivery != null)
            {
                _context.Delivery.Remove(Delivery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
