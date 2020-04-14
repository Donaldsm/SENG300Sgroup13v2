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
            _env = env; // reference to web directory 
            _context = context;
        }

        public IList<Scholarship> Scholarship { get;set; } // scholarship object

        public async Task OnGetAsync()
        {
            Scholarship = await _context.Scholarships.ToListAsync(); // await scholarship context list
            
        }

        public async Task<IActionResult> OnPostDownload(string filename)
        {

            string filePath = Path.Combine(_env.WebRootPath, "uploads", filename); // file path from uploads for downloads


            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath); // read the file 

            return File(fileBytes, "application/force-download", filename); //return the file 

        }


        private readonly IWebHostEnvironment _env;
    }
}
