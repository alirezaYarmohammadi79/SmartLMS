using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Courses;
using SmartLMS.Domain.Courses.Repository;
using SmartLMS.Domain.Courses.ValueObjects;
using SmartLMS.Domain.Teachers.Repository;

namespace SmartLMS.Application.Courses.Command.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
	private readonly ICourseRepository _courseRepo;
	private readonly ITeacherRepository _teacherRepo;

	public CreateCourseCommandHandler(ICourseRepository courseRepo,
		ITeacherRepository teacherRepo)
	{
		_courseRepo = courseRepo;
		_teacherRepo = teacherRepo;
	}

	public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken ct)
	{
		if (request.TeacherId != null)
		{
			var teacher = await _teacherRepo.GetByIdAsync(request.TeacherId.Value, ct) 
				?? throw new NotFoundException("Teacher with sent Id was not found");
		}

		var course = Course.Create(
			new CourseTitle(request.Title),
			request.Description,
			new DateRange(request.StartDate, request.EndDate),
			new Capacity(request.Capacity),
			new Price(request.Price),
			request.TeacherId
		);

		await _courseRepo.AddAsync(course, ct);
		return course.Id;
	}
}
