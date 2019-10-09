using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Creation
{
    public class BoatsModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public BoatsModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Berth"] = new SelectList(_context.Berths, "BerthId", "BerthId");
        ViewData["Person"] = new SelectList(_context.Persons, "PersonId", "FullName");
            return Page();
        }

        [BindProperty]
        public Boat Boat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Boats.Add(Boat);
            await _context.SaveChangesAsync();

            return RedirectToPage("Boats");
        }
    }
}