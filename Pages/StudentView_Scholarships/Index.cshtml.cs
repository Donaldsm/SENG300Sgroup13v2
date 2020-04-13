using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SENG300Scholarships.Data;
using SENG300Scholarships.Models;

namespace SENG300Scholarships.Pages.StudentView_Scholarships
{
    public class IndexModel : PageModel
    {
        private readonly SENG300Scholarships.Data.ScholarshipsContext _context;

        public IndexModel(SENG300Scholarships.Data.ScholarshipsContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public string TitleSort { get; set; }
        public string ValueSort { get; set; }
        public string AmountSort { get; set; }
        public string OrgSort { get; set; }
        public string DurationSort { get; set; }
        public string DeadlineSort { get; set; }
        public string ScopeSort { get; set; }
        public string MajorSort { get; set; }
        public string GPASort { get; set; }
        public IList<Scholarship> Scholarship { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            CurrentFilter = searchString;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title" : "";
            ValueSort = sortOrder == "Value" ? "value" : "Value";
            AmountSort = sortOrder == "Amount" ? "amount" : "Amount";
            OrgSort = sortOrder == "Org" ? "org" : "Org";
            DurationSort = sortOrder == "Duration" ? "duration" : "Duration";
            DeadlineSort = sortOrder == "Deadline" ? "deadline" : "Deadline";
            ScopeSort = sortOrder == "Scope" ? "scope" : "Scope";
            MajorSort = sortOrder == "Major" ? "major" : "Major";
            GPASort = sortOrder == "GPA" ? "gpa" : "GPA";


            IQueryable<Scholarship> scholarships = from s in _context.Scholarships
                                                   select s;

            switch (sortOrder)
            {
                case "title":
                    scholarships = scholarships.OrderByDescending(s => s.Title);
                    break;
                case "Value":
                    scholarships = scholarships.OrderBy(s => s.value);
                    break;
                case "value":
                    scholarships = scholarships.OrderByDescending(s => s.value);
                    break;
                case "Amount":
                    scholarships = scholarships.OrderBy(s => s.amount);
                    break;
                case "amount":
                    scholarships = scholarships.OrderByDescending(s => s.amount);
                    break;
                case "Org":
                    scholarships = scholarships.OrderBy(s => s.org);
                    break;
                case "org":
                    scholarships = scholarships.OrderByDescending(s => s.org);
                    break;
                case "Duration":
                    scholarships = scholarships.OrderBy(s => s.duration);
                    break;
                case "duration":
                    scholarships = scholarships.OrderByDescending(s => s.duration);
                    break;
                case "Deadline":
                    scholarships = scholarships.OrderBy(s => s.deadline);
                    break;
                case "deadline":
                    scholarships = scholarships.OrderByDescending(s => s.deadline);
                    break;
                case "Scope":
                    scholarships = scholarships.OrderBy(s => s.scope);
                    break;
                case "scope":
                    scholarships = scholarships.OrderByDescending(s => s.scope);
                    break;
                case "Major":
                    scholarships = scholarships.OrderBy(s => s.major);
                    break;
                case "major":
                    scholarships = scholarships.OrderByDescending(s => s.major);
                    break;
                case "GPA":
                    scholarships = scholarships.OrderBy(s => s.GPA);
                    break;
                case "gpa":
                    scholarships = scholarships.OrderByDescending(s => s.GPA);
                    break;
                default:
                    scholarships = scholarships.OrderBy(s => s.Title);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                    scholarships = scholarships.Where(s => s.GPA <= float.Parse(searchString));
            }

            Scholarship = await scholarships.ToListAsync();
        }

    }

}
