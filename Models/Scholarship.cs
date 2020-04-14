using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SENG300Scholarships.Models
{
    // this model is used to interact with the database and generate the table for Scholarships, it is also used to store the results of the queries.
    public class Scholarship
    {
        public int ScholarshipID { get; set; }
        public string Title { get; set; }
        public int value { get; set; }
        public int amount { get; set; }
        public string org { get; set; }
        //public string img { get; set; }
        public string duration { get; set; }
        public DateTime deadline { get; set; }
        public string scope { get; set; }
        public string major { get; set; }
        public float GPA { get; set; }
        //public string[] candidates { get; set; }
        public string UploadPath { get; set; }
       

        public ICollection<Submission> Submissions { get; set; }
    }
}
