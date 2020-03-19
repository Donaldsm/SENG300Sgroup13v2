using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Pages.StudentView_Scholarships
{
    public class DetailsModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public DetailsModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        public Scholarship Scholarship { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scholarship = await _context.Scholarships.FirstOrDefaultAsync(m => m.ScholarshipID == id);

            if (Scholarship == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
