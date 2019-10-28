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
    public class DeleteModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public DeleteModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }
        public IList<Boat> Boats { get; set; }
        public string ErrorMsg { get; set; } = "";

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Persons.FindAsync(id);
            Boats = await _context.Boats.ToListAsync();

            if (Person != null)
            {
                if (Person.Boats != null)
                {
                    ErrorMsg = "Kunden har en båd, man kan ikke slette en kunde som har en båd i haven.";
                    return Page();
                }
                else
                {
                    _context.Persons.Remove(Person);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            else
            {
                return RedirectToPage("./Index");
            }

        }
    }
}
