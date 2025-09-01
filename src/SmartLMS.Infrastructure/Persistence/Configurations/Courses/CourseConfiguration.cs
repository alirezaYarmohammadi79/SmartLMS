using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Courses.Entities;
using SmartLMS.Domain.Courses;
using SmartLMS.Domain.Courses.ValueObjects;

namespace SmartLMS.Infrastructure.Persistence.Configurations.Courses;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        ConfigureCoursesTable(builder);
    }

    public void ConfigureCoursesTable(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
               .HasConversion(
                   v => v.Value,
                   v => new CourseTitle(v))
               .HasMaxLength(200)
               .IsRequired()
               .HasColumnName("Title");

        builder.Property(c => c.Description)
               .HasMaxLength(1000)
               .IsRequired();

        builder.OwnsOne(c => c.Period, period =>
        {
            period.Property(p => p.Start).HasColumnName("StartDate").IsRequired();
            period.Property(p => p.End).HasColumnName("EndDate").IsRequired();
        });

        builder.Property(c => c.Capacity)
            .HasConversion(
                c => c.MaxSeats,
                c => new Capacity(c)
            )
            .IsRequired()
            .HasColumnName("Capacity");

        builder.OwnsOne(c => c.Price, price =>
        {
            price.Property(p => p.Amount)
                 .HasColumnName("Price")
                 .HasPrecision(18, 2)
                 .IsRequired();
        });

        builder.Property(c => c.TeacherId)
               .HasConversion(
                   t => t.Value,
                   t => new TeacherId(t))
               .IsRequired()
               .HasColumnName("TeacherId");

        // Enrollments collection (private field)
        builder.Navigation(nameof(Course.Enrollments))
               .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
