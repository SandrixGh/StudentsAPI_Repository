using Microsoft.EntityFrameworkCore;
using StudentsAPI.DAL.Configurations;
using StudentsAPI.DAL.Entities;

namespace StudentsAPI.DAL
{
    public class StudentsAPIDbContext : DbContext
    {
        public StudentsAPIDbContext(DbContextOptions<StudentsAPIDbContext> options) : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<UniversityEntity> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new UniversitiesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
