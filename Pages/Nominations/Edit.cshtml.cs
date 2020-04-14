using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

//this cshtml file is to set up and edit existing nominations


namespace SENG300Scholarships.Pages.Nominations
{
    public class EditModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public EditModel(SENG300Scholarships.Data.ScholarshipsContext context)
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

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nomination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominationExists(Nomination.NominationID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NominationExists(int id)
        {
            return _context.Nominations.Any(e => e.NominationID == id);
        }
    }
}
