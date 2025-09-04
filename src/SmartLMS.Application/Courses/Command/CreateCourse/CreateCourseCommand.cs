using MediatR;

namespace SmartLMS.Application.Courses.Command.CreateCourse;

public record CreateCourseCommand(
	string Title,
	string Description,
	DateTime StartDate,
	DateTime EndDate,
	int Capacity,
	decimal Price,
	Guid? TeacherId
) : IRequest<Guid>;