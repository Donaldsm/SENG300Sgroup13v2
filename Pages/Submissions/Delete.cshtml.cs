﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public DeleteModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Submission = await _context.Submissions.FindAsync(id);

            if (Submission != null)
            {
                _context.Submissions.Remove(Submission);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
