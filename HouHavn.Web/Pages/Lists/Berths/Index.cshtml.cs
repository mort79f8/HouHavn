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
    public class IndexModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public IndexModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        public IList<Berth> Berth { get;set; }

        public async Task OnGetAsync()
        {
            Berth = await _context.Berths.ToListAsync();
        }
    }
}
