using Fleet_tracking_system.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fleet_tracking_system.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehicles> Vehicles { get; set; }

        public DbSet<ServiceReport> ServiceReports { get; set; }

        public DbSet<Trip> trips { get; set; }

        public DbSet<Timesheet> timesheets { get; set; }


       
       
    }
}
