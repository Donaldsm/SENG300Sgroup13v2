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

namespace SENG300Scholarships.Pages.Submissions
{
    public class CoordModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public CoordModel(SENG300Scholarships.Data.ScholarshipsContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env; 
        }

        public IList<Submission> Submission { get;set; }

        public async Task OnGetAsync()
        {
            Submission = await _context.Submissions.ToListAsync();
        }

        private readonly IWebHostEnvironment _env;

        public async Task<IActionResult> OnPostDownload(string filename)
        {

            string filePath = Path.Combine(_env.WebRootPath, "subup", filename);


            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", filename);

        }

    }
}
