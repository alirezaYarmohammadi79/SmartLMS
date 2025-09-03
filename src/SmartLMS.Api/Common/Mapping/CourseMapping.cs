using Mapster;
using SmartLMS.Application.Courses.Command.CreateCourse;
using SmartLMS.Application.Courses.Command.SetFinalGradeCommand;
using SmartLMS.Contracts.Courses;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Api.Common.Mapping;

public class CourseMapping : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		// ----------------------
		// Commands
		// ----------------------

		config.NewConfig<CreateCourseRequest, CreateCourseCommand>();
		//config.NewConfig<UpdateCourseRequest, UpdateCourseCommand>();
		//config.NewConfig<EnrollStudentRequest, EnrollStudentCommand>();
		config.NewConfig<SetGradeRequest, SetFinalGradeCommand>();

		// ----------------------
		// Queries
		// ----------------------

		config.NewConfig<Course, CourseResponse>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Title, src => src.Title.Value) 
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.StartDate, src => src.Period.Start)
			.Map(dest => dest.EndDate, src => src.Period.End)
			.Map(dest => dest.Capacity, src => src.Capacity.MaxSeats)
			.Map(dest => dest.RemainingSeats, src => src.RemainingSeats())
			.Map(dest => dest.Price, src => src.Price.Amount) 
			.Map(dest => dest.TeacherId, src => src.TeacherId.Value); 
		;
	}
}
