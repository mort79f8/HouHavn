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
    public class IndexModel : PageModel
    {
        private readonly HouhavnContext _context;

        public IndexModel(HouhavnContext context)
        {
            _context = context;
        }

        public IList<Boat> Boat { get;set; }

        public async Task OnGetAsync()
        {
            Boat = await _context.Boats
                .Include(b => b.BerthNavigation)
                .Include(b => b.PersonNavigation).OrderBy(o => o.Name).ToListAsync();
        }
    }
}
