using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Boats
{
    public class DetailsModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public DetailsModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
