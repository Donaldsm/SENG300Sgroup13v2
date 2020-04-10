using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Pages.Scholarships
{
    public class IndexModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public IndexModel(SENG300Scholarships.Data.ScholarshipsContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        public IList<Scholarship> Scholarship { get;set; }

        public async Task OnGetAsync()
        {
            Scholarship = await _context.Scholarships.ToListAsync();
            
        }

        public async Task<IActionResult> OnPostDownload(string filename)
        {

            string filePath = Path.Combine(_env.WebRootPath, "uploads", filename);


            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", filename);

        }


        private readonly IWebHostEnvironment _env;
    }
}
