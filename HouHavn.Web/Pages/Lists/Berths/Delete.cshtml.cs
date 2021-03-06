﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HouHavn.Web.Model;

namespace HouHavn.Web.Pages.Lists.Berths
{
    public class DeleteModel : PageModel
    {
        private readonly HouHavn.Web.Model.HouhavnContext _context;

        public DeleteModel(HouHavn.Web.Model.HouhavnContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Berth Berth { get; set; }
        public IList<Boat> Boats { get; set; }
        public string ErrorMessagse { get; set; } = "";

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Berth = await _context.Berths.FindAsync(id);
            Boats = await _context.Boats.ToListAsync();

            if (Berth.Boats.Count > 0)
            {
                ErrorMessagse = "Der er en båd på denne plads, og kan derfor ikke slettes";
            }
            else
            {
                if (Berth != null)
                {
                    _context.Berths.Remove(Berth);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }

            return Page();
        }
    }
}
