using SmartLMS.Domain.Courses;

namespace SmartLMS.Application.Course.Command.SetFinalGradeCommand;

public class SetFinalGradeCommandHandler
{
	private readonly ICourseRepository _courseRepository;

	public SetFinalGradeCommandHandler(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task Handle(SetFinalGradeCommand command, CancellationToken ct)
	{
		await _courseRepository.SetFinalGradeAsync(command.CourseId, command.StudentId, command.Grade , ct);
	}
}