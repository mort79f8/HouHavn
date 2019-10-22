using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouHavn.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HouHavn.Web.Pages.Creation
{
    public class BoatInfoModel : PageModel
    {

        private readonly HouhavnContext _context;
        [BindProperty(SupportsGet = true)]
        public int BoatId { get; set; }
        public Boat Boat { get; set; }

        public IList<Boat> Boats { get; set; }
        public IList<Person> People { get; set; }

        public BoatInfoModel(HouhavnContext context)
        {
            _context = context;

        }

        public async Task OnGetAsync()
        {
            Boats = await _context.Boats.ToListAsync();
            Boat = Boats.Where(b => b.BoatId == BoatId).FirstOrDefault();
            People = await _context.Persons.ToListAsync();
        }

    }
}