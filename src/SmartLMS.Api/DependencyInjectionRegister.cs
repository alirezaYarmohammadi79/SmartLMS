using SmartLMS.Api.Common.Mapping;

namespace SmartLMS.Api;

public static class DependencyInjectionRegister
{
	public static IServiceCollection AddPresentaion(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
		services.AddProblemDetails();
		services.AddMappings();


		return services;
	}
}
