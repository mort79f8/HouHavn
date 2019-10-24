using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Lists.Berths
{
    public class DetailsModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public DetailsModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        public Berth Berth { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Berth = await _context.Berths.FirstOrDefaultAsync(m => m.BerthId == id);

            if (Berth == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
