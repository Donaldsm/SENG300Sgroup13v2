using System;
namespace SENG300Scholarships.Models
{
    public class Nomination
    {
        // this model is used to interact with the database and generate the table for Nominations, it is also used to store the results of the queries.
        public int NominationID { get; set; }
        public string ScholarshipID { get; set; }
        public string UserId { get; set; }
        public string Letter { get; set; }


    }
    
}
