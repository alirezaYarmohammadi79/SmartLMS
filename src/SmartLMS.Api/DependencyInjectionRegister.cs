namespace SmartLMS.Api;

public static class DependencyInjectionRegister
{
	public static IServiceCollection AddPresentaion(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
		services.AddProblemDetails();

		return services;
	}
}
