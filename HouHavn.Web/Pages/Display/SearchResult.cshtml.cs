using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouHavn.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HouHavn.Web.Pages.Display
{
    public class SearchResultModel : PageModel
    {
        private readonly HouhavnContext _context;

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        public List<Boat> Boatlist { get; set; }


        public IList<Berth> Berth { get; set; }
        public IList<Boat> Boats { get; set; }
        public IList<Person> People { get; set; }

        public SearchResultModel(HouhavnContext context)
        {
            _context = context;

        }


        public async Task OnGetAsync()
        {
            Berth = await _context.Berths.ToListAsync();
            Boats = await _context.Boats.ToListAsync();
            People = await _context.Persons.ToListAsync();
            Search(SearchQuery);
        }

        private void Search(string searchquery)
        {
            Boatlist = Boats.Where(b =>
                b.PersonNavigation.FullName.ToLower().Contains(searchquery.ToLower()) ||
                b.Name.ToLower().Contains(searchquery.ToLower()) ||
                b.Type.ToLower().Contains(searchquery.ToLower())
                ).ToList();
        }
    }
}