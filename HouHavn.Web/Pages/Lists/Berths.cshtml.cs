using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Lists
{
    public class BerthsModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;
       

        public BerthsModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;

        }



        public IList<Boat> Boat { get;set; }

        public async Task OnGetAsync()
        {
            Boat = await _context.Boats
                .Include(b => b.BerthNavigation)
                .Include(b => b.PersonNavigation).ToListAsync();
        }
    }
}
