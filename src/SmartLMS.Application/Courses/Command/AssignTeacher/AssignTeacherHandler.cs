using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Courses.Repository;
using SmartLMS.Domain.Teachers.Repository;

namespace SmartLMS.Application.Courses.Command.AssignTeacher;

public class AssignTeacherHandler : IRequestHandler<AssignTeacherCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ITeacherRepository _teacherRepository;

    public AssignTeacherHandler(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
    {
        _courseRepository = courseRepository;
        _teacherRepository = teacherRepository;
    }


    public async Task Handle(AssignTeacherCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId , cancellationToken)
           ?? throw new NotFoundException($"Course {request.CourseId} not found");

        var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId , cancellationToken)
            ?? throw new NotFoundException($"Teacher {request.TeacherId} not found");

        course.AssignTeacher(teacher.Id);

        await _courseRepository.UpdateAsync(course, cancellationToken);
    }
}
