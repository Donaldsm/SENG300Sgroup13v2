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
    public class IndexModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public IndexModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }

        public IList<Scholarship> Scholarship { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Scholarship> scholarships = from s in _context.Scholarships
                                                   select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                    scholarships = scholarships.Where(s => s.GPA <= float.Parse(searchString));
            }

            Scholarship = await scholarships.ToListAsync();
        }

    }

}
