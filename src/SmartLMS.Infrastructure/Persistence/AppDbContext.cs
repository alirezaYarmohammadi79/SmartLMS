using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Common.Models;
using SmartLMS.Domain.Courses;
using SmartLMS.Domain.Students;
using SmartLMS.Domain.Teachers;
using SmartLMS.Infrastructure.Persistence.Interceptors;
using SmartLMS.Domain.Courses.Entities;

namespace SmartLMS.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public AppDbContext(DbContextOptions<AppDbContext> options,
       PublishDomainEventsInterceptor publishDomainEventsInterceptor = null!
	) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .AddInterceptors(_publishDomainEventsInterceptor);

        base.OnConfiguring(optionsBuilder);
    }
}
