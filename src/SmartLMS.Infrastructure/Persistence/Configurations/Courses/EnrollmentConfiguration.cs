using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Courses.Entities;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Infrastructure.Persistence.Configurations.Courses;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.StudentId)
               .IsRequired();

        builder.Property(e => e.Grade)
               .HasColumnName("Grade")
               .HasPrecision(5, 2);

        builder.Property<DateTime>("EnrollmentDate")
               .IsRequired();

        builder.HasOne<Course>()
               .WithMany("_enrollments")
               .HasForeignKey("CourseId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
