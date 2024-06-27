using FacultyScheduleWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FacultyScheduleWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Workspace> Spaces { get; set; }
        public DbSet<AcademianClass> Academians { get; set; }
        public DbSet<DateCellClass> DateCells { get; set; }
    }
}