using MediatR;
using SmartLMS.Domain.Courses;
using SmartLMS.Domain.Courses.ValueObjects;

namespace SmartLMS.Application.Courses.Command.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
	private readonly ICourseRepository _courseRepo;

	public CreateCourseCommandHandler(ICourseRepository courseRepo)
	{
		_courseRepo = courseRepo;
	}

	public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken ct)
	{
		var course = Course.Create(
			new CourseTitle(request.Title),
			request.Description,
			new DateRange(request.StartDate, request.EndDate),
			new Capacity(request.Capacity),
			new Price(request.Price),
			new TeacherId(request.TeacherId)
		);

		await _courseRepo.AddAsync(course, ct);
		return course.Id;
	}
}
