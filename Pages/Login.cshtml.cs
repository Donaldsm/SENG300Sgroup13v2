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

        
        // the purpose of the code below is to do a database query to make sure the user that is entered on the login
        // submission is in the database. Should a user exist matching the username and password, the system
        // should redirect to the correct home page for that user.
        public async Task<IActionResult> OnGetAsync()
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var users = await _context.Users.FirstOrDefaultAsync(u => u.UserId == username && u.Password == password);

                if(users != null)
                {
                    if (users.Type.ToUpper() == "STUDENT")
                    {
                        return RedirectToPage("/StudentView_Scholarships/Index");
                    } 
                    else if (users.Type.ToUpper() == "INSTRUCTOR")
                    {
                        return RedirectToPage("/Nominations/Index");
                    }
                    else if (users.Type.ToUpper() == "ADMINISTRATOR" || users.Type.ToUpper() == "ADMIN")
                    {
                        return RedirectToPage("/Users/Index");
                    }
                    else if (users.Type.ToUpper() == "COORDINATOR")
                    {
                        return RedirectToPage("/Coordinator/Index");
                    }
                    return RedirectToPage("/Index"); // the default return to home if there was no type entered with account registration.
                }
            }
            return Page(); // if there was no user found this should keep the person attempting to log in on the login page.

        }
    }
}