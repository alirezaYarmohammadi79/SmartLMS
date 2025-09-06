using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Courses.Repository;
using SmartLMS.Domain.Students.Repository;

namespace SmartLMS.Application.Courses.Command.SetFinalGradeCommand;

public class SetFinalGradeCommandHandler : IRequestHandler<SetFinalGradeCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IStudentRepository _studentRepository;

	public SetFinalGradeCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository)
	{
		_courseRepository = courseRepository;
		_studentRepository = studentRepository;
	}

	public async Task Handle(SetFinalGradeCommand request, CancellationToken ct)
	{
        var course = await _courseRepository.GetByIdAsync(request.CourseId, ct)
        ?? throw new NotFoundException("Course not found");

        var student = await _studentRepository.GetByIdAsync(request.StudentId, ct);

        if (student is null)
            throw new NotFoundException("student not found");

        course.AssignGrade(student.Id , request.Grade);

        await _courseRepository.UpdateAsync(course, ct);
    }
}