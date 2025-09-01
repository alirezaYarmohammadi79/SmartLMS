using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLMS.Domain.Courses;
using SmartLMS.Domain.Courses.Entities;
using SmartLMS.Domain.Students;

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

		builder.HasOne<Student>()
	           .WithMany()
	           .HasForeignKey(e=> e.StudentId)
	           .OnDelete(DeleteBehavior.Cascade);

		builder.HasOne<Course>()
               .WithMany(c => c.Enrollments)
               .HasForeignKey("CourseId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
