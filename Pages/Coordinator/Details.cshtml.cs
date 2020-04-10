using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Pages.Submissions
{
    public class CoordDetailsModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public CoordDetailsModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        public Submission Submission { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Submission = await _context.Submissions.FirstOrDefaultAsync(m => m.SubmissionId == id);

            if (Submission == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
