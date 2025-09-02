using Microsoft.Extensions.DependencyInjection;

namespace SmartLMS.Application;

public static class DependecyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(options =>
		{
			options.RegisterServicesFromAssemblyContaining(typeof(DependecyInjection));
		});
		return services;
	}
}