using Microsoft.EntityFrameworkCore;
using StudentsAPI.DAL.Entities;

namespace StudentsAPI.DAL
{
    public class StudentsAPIDbContext : DbContext
    {
        public StudentsAPIDbContext(DbContextOptions<StudentsAPIDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<StudentEntity> Students {  get; set; } 
    }
}
