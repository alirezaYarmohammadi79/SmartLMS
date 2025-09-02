using MediatR;

namespace SmartLMS.Application.Course.Command.CreateCourse;

public record CreateCourseCommand(
	string Title,
	string Description,
	DateTime StartDate,
	DateTime EndDate,
	int Capacity,
	decimal Price,
	Guid TeacherId
) : IRequest<Guid>;