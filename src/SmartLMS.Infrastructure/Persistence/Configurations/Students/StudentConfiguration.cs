using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Students;
using SmartLMS.Domain.Common.ValueObjects;
using SmartLMS.Domain.Students.ValueObjects;

namespace SmartLMS.Infrastructure.Persistence.Configurations.Students;

internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .ValueGeneratedNever();

        builder.OwnsOne(s => s.FullName, fn =>
        {
            fn.Property(f => f.FirstName)
              .HasColumnName("FirstName")
              .HasMaxLength(100)
              .IsRequired();

            fn.Property(f => f.LastName)
              .HasColumnName("LastName")
              .HasMaxLength(100)
              .IsRequired();
        });

        builder.Property(s => s.Email)
               .HasConversion(
                   e => e.Value,
                   e => new Email(e))
               .HasColumnName("Email")
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(s => s.DateOfBirth)
               .HasConversion(
                   dob => dob.Value,
                   dob => new DateOfBirth(dob))
               .HasColumnName("DateOfBirth")
               .IsRequired();

        builder.Property(s => s.Status)
               .IsRequired();
    }
}