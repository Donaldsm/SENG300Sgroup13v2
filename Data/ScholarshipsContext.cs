using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Data
{
    public class ScholarshipsContext : DbContext
    {
        public ScholarshipsContext (DbContextOptions<ScholarshipsContext> options)
            : base(options)
        {
        }

        public DbSet<SENG300Scholarships.Models.User> Users { get; set; }
        public DbSet<SENG300Scholarships.Models.Submission> Submissions { get; set; }
        public DbSet<SENG300Scholarships.Models.Scholarship> Scholarships { get; set; }
        public DbSet<SENG300Scholarships.Models.Nomination> Nominations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");                // this is using the model information found in Users.cs in the models folder to build a table for the users based on the variabels found in the file
            modelBuilder.Entity<Submission>().ToTable("Submission");    // this is using the model information found in Submission.cs in the models folder to build a table for the users based on the variabels found in the file
            modelBuilder.Entity<Scholarship>().ToTable("Scholarship");  // this is using the model information found in Scholarship.cs in the models folder to build a table for the users based on the variabels found in the file
            modelBuilder.Entity<Nomination>().ToTable("Nomination");    // this is using the model information found in Nomination.cs in the models folder to build a table for the users based on the variabels found in the file

        }
    }
}
