using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Lists.People
{
    public class DetailsModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public DetailsModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }
        public IList<Boat> Boats { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);
            Boats = await _context.Boats.ToListAsync();

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
