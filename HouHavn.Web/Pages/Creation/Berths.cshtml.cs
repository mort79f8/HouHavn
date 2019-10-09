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
    public class BerthsModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public BerthsModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Berth Berth { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Berths.Add(Berth);
            await _context.SaveChangesAsync();

            return RedirectToPage("Berths");
        }
    }
}