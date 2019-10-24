using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Boats
{
    public class EditModel : PageModel
    {
        private readonly HouhavnContext _context;

        public EditModel(HouhavnContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Boat Boat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Boat = await _context.Boats
                .Include(b => b.BerthNavigation)
                .Include(b => b.PersonNavigation).FirstOrDefaultAsync(m => m.BoatId == id);

            if (Boat == null)
            {
                return NotFound();
            }
           ViewData["Berth"] = new SelectList(_context.Berths.Where(b => b.Boats.Count == 0 || b.Boats.FirstOrDefault() == Boat), "BerthId", "BerthId");
           ViewData["Person"] = new SelectList(_context.Persons, "PersonId", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Boat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoatExists(Boat.BoatId))
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

        private bool BoatExists(int id)
        {
            return _context.Boats.Any(e => e.BoatId == id);
        }
    }
}
