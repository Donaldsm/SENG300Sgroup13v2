using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Pages.Submissions
{
    public class CreateModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public CreateModel(SENG300Scholarships.Data.ScholarshipsContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        private readonly IWebHostEnvironment _env;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Submission Submission { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        public IFormFile studentLoad { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          

            if (studentLoad == null)
            {
                Submission.File = "no file";
            }
            else
            {
                var file = Path.Combine(_env.WebRootPath, "subup", studentLoad.FileName);
                Submission.File = (studentLoad.FileName);


                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await studentLoad.CopyToAsync(fileStream);

                }
            }

            Submission.Status = "Pending";

            _context.Submissions.Add(Submission);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
