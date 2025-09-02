using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SmartLMS.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
	public AppDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

		// Load connection string from appsettings.json
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var connectionString = config.GetConnectionString("SQLConnection");

		optionsBuilder.UseSqlServer(connectionString); // adjust for your DB

		// At design time, you can pass null for the interceptor
		return new AppDbContext(optionsBuilder.Options, publishDomainEventsInterceptor: null);
	}
}