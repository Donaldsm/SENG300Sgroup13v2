using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENG300Scholarships.Models
{
    // this model is used to interact with the database and generate the table for Users, it is also used to store the results of the queries.
    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
    }
}
