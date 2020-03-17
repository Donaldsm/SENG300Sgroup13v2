using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Pages.Nominations
{
    public class IndexModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public IndexModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        public IList<Nomination> Nomination { get;set; }

        public async Task OnGetAsync()
        {
            Nomination = await _context.Nominations.ToListAsync();
        }
    }
}
