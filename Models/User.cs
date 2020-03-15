using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENG300Scholarships.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
    }
}
