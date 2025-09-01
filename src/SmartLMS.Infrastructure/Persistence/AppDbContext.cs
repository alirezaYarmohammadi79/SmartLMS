using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Common.Models;
using SmartLMS.Domain.Courses;
using SmartLMS.Domain.Students;
using SmartLMS.Domain.Teachers;
using SmartLMS.Infrastructure.Persistence.Configurations.Courses;
using SmartLMS.Infrastructure.Persistence.Configurations.Students;
using SmartLMS.Infrastructure.Persistence.Configurations.Teachers;
using SmartLMS.Infrastructure.Persistence.Interceptors;

namespace SmartLMS.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();

    public AppDbContext(DbContextOptions<AppDbContext> options,
       PublishDomainEventsInterceptor publishDomainEventsInterceptor
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
