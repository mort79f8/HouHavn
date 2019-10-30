using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HouhavnContext _context;

        public IndexModel(HouhavnContext context)
        {
            _context = context;

        }

        public IList<Berth> Berth { get;set; }
        public IList<Boat> Boats { get;set; }
        public IList<Person> People { get; set; }

        public async Task OnGetAsync()
        {
            Berth = await _context.Berths.ToListAsync();
            Boats = await _context.Boats.ToListAsync();
            People = await _context.Persons.ToListAsync();
        }

    }
}
