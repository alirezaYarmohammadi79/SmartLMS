using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;
using SmartLMS.Domain.Courses.Repository;
using SmartLMS.Domain.Students.Repository;
using SmartLMS.Domain.Teachers.Repository;
using SmartLMS.Infrastructure.Persistence;
using SmartLMS.Infrastructure.Persistence.Interceptors;
using SmartLMS.Infrastructure.Persistence.Repositories;

namespace SmartLMS.Infrastructure;

public static class DependencyInjectionRegister
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configration)
	{
		services
			.AddPersistance(configration);


		return services;
	}

	public static IServiceCollection AddPersistance(this IServiceCollection services , IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("SQLConnection")));

		services.AddScoped<PublishDomainEventsInterceptor>();
		services.AddScoped<ICourseRepository, CourseRepository>();
		services.AddScoped<ITeacherRepository, TeacherRepository>();
		services.AddScoped<IStudentRepository, StudentRepository>();
		services.AddScoped<ICourseReadRepository, CourseReadRepository>();

		return services;
	}

}