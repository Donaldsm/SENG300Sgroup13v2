using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

//this cshtml file is to set up and create new nominations

namespace SENG300Scholarships.Pages.Nominations
{
    public class CreateModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public CreateModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nomination Nomination { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nominations.Add(Nomination);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
