using IncidentReport.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Data
{
    public class IRcontext : DbContext
    {
        public IRcontext(DbContextOptions<IRcontext> options):base(options)    
        {

        }

        public DbSet<Crime> Crimes { get; set; }
        public DbSet<InvestigativeReport> InvestigativeReports { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocType> LocTypes { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonLocation> PersonLocations { get; set; }
        public DbSet<ReportLocation> ReportLocations { get; set; }
        public DbSet<ReportOfficer> ReportOfficers { get; set; }
        public DbSet<ReportPerson> ReportPersons { get; set; }
        public DbSet<Role> Roles { get; set; }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(@"server=192.168.1.114;user=Rick;password=million;database=incidentreport;port=3306");
        }
    }
}
