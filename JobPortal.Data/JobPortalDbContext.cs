using JobPortal.Model;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>  Users { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<AcademicInfo> AcademicInfos { get; set; } // Add this line

        public DbSet<Designation> Designations { get; set; }

        public DbSet<EmploymentInfo> EmploymentInfos { get; set; }

        public DbSet<ExperienceInfo> Experiences { get; set; }

        public DbSet<Country>  Countries { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<AddressInfo>  AddressInfos { get; set; }
    }
}
