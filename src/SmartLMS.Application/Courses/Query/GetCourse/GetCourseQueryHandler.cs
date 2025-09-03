using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Application.Courses.Query.GetCourse;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, Course>
{
	private readonly ICourseRepository _courseRepository;

	public GetCourseQueryHandler(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task<Course> Handle(GetCourseQuery request, CancellationToken cancellationToken)
	{
		var course = await _courseRepository.GetByIdAsync(request.CourseId, cancellationToken)
			?? throw new NotFoundException("Course not found");

		return course;
	}
}
