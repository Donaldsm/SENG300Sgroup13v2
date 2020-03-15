using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;

namespace SENG300Scholarships
{
    public class LoginModel : PageModel
    {
        private readonly ScholarshipsContext _context;

        public LoginModel(ScholarshipsContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string username { get; set; }
        [BindProperty(SupportsGet = true)]
        public string password { get; set; }

        

        public async Task<IActionResult> OnGetAsync()
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var users = await _context.Users.FirstOrDefaultAsync(u => u.UserId == username && u.Password == password);

                if(users != null)
                {
                    return RedirectToPage("/Scholarships/Index");
                }
            }
            return Page();

        }
    }
}