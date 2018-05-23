using System.Data.Entity;

namespace AcademyApplication.Models
{
    public class AcademyAppDbContext : DbContext
    {
        public AcademyAppDbContext() : base("AcademyDb")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}