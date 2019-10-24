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
        private readonly HouhavnContext _context;

        public BerthsModel(HouhavnContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Berth Berth { get; set; }
        public int NextId { get => _context.Berths.Last().BerthId + 1; }
        public string ErrorMessage { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool exists = false;

            foreach (var item in _context.Berths)
            {
                if(item.BerthId == Berth.BerthId)
                {
                    exists = true;
                }
            }

            if (exists)
            {
                ErrorMessage = "Pladsen findes allerede";
                return Page();
            }
            else
            {
                _context.Berths.Add(Berth);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Berths");
        }
    }
}