using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsAPI.Core.Models;
using StudentsAPI.DAL.Entities;

namespace StudentsAPI.DAL.Configurations
{
    public class UniversitiesConfiguration : IEntityTypeConfiguration<UniversityEntity>
    {
        public void Configure(EntityTypeBuilder<UniversityEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(University.MAX_NAME_LENGTH);
        }
    }
}
