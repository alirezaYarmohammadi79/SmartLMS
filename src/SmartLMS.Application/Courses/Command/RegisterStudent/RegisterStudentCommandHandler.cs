using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Application.Courses.Command.RegisterStudent;

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand>
{
	private readonly ICourseRepository _courseRepo;

	public RegisterStudentCommandHandler(ICourseRepository courseRepo)
	{
		_courseRepo = courseRepo;
	}

	public async Task Handle(RegisterStudentCommand request, CancellationToken ct)
	{
		var course = await _courseRepo.GetByIdAsync(request.CourseId, ct)
			?? throw new NotFoundException("Course not found");

		course.EnrollStudent(request.StudentId);
		await _courseRepo.UpdateAsync(course, ct);
	}
}