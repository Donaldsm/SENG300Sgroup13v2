using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

//this cshtml file is to returns the current status of a nomination

namespace SENG300Scholarships.Pages.Nominations
{
    public class DetailsModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public DetailsModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

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
    }
}
