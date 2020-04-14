using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

//this cshtml file is to set up and delete existing nominations

namespace SENG300Scholarships.Pages.Nominations
{
    public class DeleteModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public DeleteModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomination Nomination { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nomination = await _context.Nominations.FirstOrDefaultAsync(m => m.NominationID == id);

            if (Nomination == null)
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

            Nomination = await _context.Nominations.FindAsync(id);

            if (Nomination != null)
            {
                _context.Nominations.Remove(Nomination);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
