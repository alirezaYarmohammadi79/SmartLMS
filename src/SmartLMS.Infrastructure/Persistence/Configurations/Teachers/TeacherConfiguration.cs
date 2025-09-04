using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Common.ValueObjects;
using SmartLMS.Domain.Teachers;

namespace SmartLMS.Infrastructure.Persistence.Configurations.Teachers;

internal sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .ValueGeneratedNever();

        builder.OwnsOne(t => t.FullName, fn =>
        {
            fn.Property(f => f.FirstName)
              .HasMaxLength(100)
              .IsRequired()
              .HasColumnName("FirstName");

            fn.Property(f => f.LastName)
              .HasMaxLength(100)
              .IsRequired()
              .HasColumnName("LastName");
        });

        builder.Property(t => t.Email)
               .HasConversion(
                   e => e.Value,
                   e => new Email(e))
               .HasColumnName("Email")
               .HasMaxLength(200)
               .IsRequired();
    }
}