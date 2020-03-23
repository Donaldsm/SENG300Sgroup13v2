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

namespace SENG300Scholarships.Pages.Scholarships
{
    public class CreateModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public CreateModel(SENG300Scholarships.Data.ScholarshipsContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
         
            return Page();
        }

        [BindProperty]
        public Scholarship Scholarship { get; set; }






        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IFormFile Upload { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            var file = Path.Combine(_env.WebRootPath, "uploads", Upload.FileName);
            Scholarship.UploadPath = Path.Combine(_env.WebRootPath, "uploads", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);

            }

            _context.Scholarships.Add(Scholarship);
            await _context.SaveChangesAsync();

           


            return RedirectToPage("./Index") ;
        }
        private readonly IWebHostEnvironment _env;

    
    }
}

