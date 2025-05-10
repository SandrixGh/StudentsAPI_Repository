using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsAPI.Core.Models;
using StudentsAPI.DAL.Entities;

namespace StudentsAPI.DAL.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Student.MAX_NAME_LENGTH);

            builder.Property(x => x.Grade)
                .IsRequired();
        }
    }
}
