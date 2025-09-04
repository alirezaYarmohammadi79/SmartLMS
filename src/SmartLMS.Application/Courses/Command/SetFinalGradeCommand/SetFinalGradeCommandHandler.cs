using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Courses.Repository;

namespace SmartLMS.Application.Courses.Command.SetFinalGradeCommand;

public class SetFinalGradeCommandHandler
{
	private readonly ICourseRepository _courseRepository;

	public SetFinalGradeCommandHandler(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task Handle(SetFinalGradeCommand request, CancellationToken ct)
	{
        var course = await _courseRepository.GetByIdAsync(request.CourseId, ct)
        ?? throw new NotFoundException("Course not found");

        var student = await _courseRepository.GetByIdAsync(request.StudentId, ct);

        if (student is null)
            throw new NotFoundException("student not found");

        course.AssignGrade(student.Id , request.Grade);

        await _courseRepository.UpdateAsync(course, ct);
    }
}