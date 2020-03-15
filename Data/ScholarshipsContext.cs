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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Submission>().ToTable("Submission");
            modelBuilder.Entity<Scholarship>().ToTable("Scholarship");

        }
    }
}
