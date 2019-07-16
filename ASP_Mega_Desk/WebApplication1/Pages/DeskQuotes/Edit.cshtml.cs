using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Models.WebApplication1Context _context;

        public EditModel(WebApplication1.Models.WebApplication1Context context)
        {
            

                _context = context;
                IQueryable<string> matQuery = from m in _context.Material
                                              orderby m.MaterialType
                                              select m.MaterialType;

                IQueryable<string> delQuery = from d in _context.Delivery
                                              orderby d.RushOrderDay
                                              select d.RushOrderDay;

                MaterialList = new SelectList(matQuery.Distinct().ToList());
                DeliveryList = new SelectList(delQuery.Distinct().ToList());


            
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }
        public SelectList DeliveryList { get; set; }
        public SelectList MaterialList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Delivery)
                .Include(d => d.Desk).FirstOrDefaultAsync(m => m.DeskQuoteID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
           ViewData["DeliveryID"] = new SelectList(_context.Delivery, "DeliveryID", "DeliveryID");
           ViewData["DeskID"] = new SelectList(_context.Desk, "DeskID", "DeskID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.DeskQuoteID == id);
        }
    }
}
