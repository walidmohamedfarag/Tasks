
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data
{
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<HomeWorkSubMissions> HomeWorkSubMissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Initial Catalog=EFTask1;Encrypt=True;" +
                "Trust Server Certificate=True;");
        }
    }
}
