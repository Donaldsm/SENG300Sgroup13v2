using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENG300Scholarships.Models
{
     // this model is used to interact with the database and generate the table for Submissions, it is also used to store the results of the queries.
    public class Submission
    {
        public int SubmissionId { get; set; }
        public string Student { get; set; }
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string School { get; set; }
        public double GPA { get; set; }
        public double Year { get; set; }
        public int ScholarshipID { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceEmail { get; set;} 
        public string Status {get; set;}

        public string File { get; set; }
        
    }
}
