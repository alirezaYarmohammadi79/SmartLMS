using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Courses.Repository;
using SmartLMS.Domain.Students.Repository;

namespace SmartLMS.Application.Courses.Command.RegisterStudent;

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand>
{
    private readonly ICourseRepository _courseRepo;
    private readonly IStudentRepository _studentRepo;

    public RegisterStudentCommandHandler(ICourseRepository courseRepo, IStudentRepository studentRepo)
    {
        _courseRepo = courseRepo;
        _studentRepo = studentRepo;
    }

    public async Task Handle(RegisterStudentCommand request, CancellationToken ct)
    {
        var course = await _courseRepo.GetByIdAsync(request.CourseId, ct)
            ?? throw new NotFoundException("Course not found");

        var student = await _studentRepo.GetByIdAsync(request.StudentId, ct);

        if (student is null)
            throw new NotFoundException("student not found");

        course.EnrollStudent(student.Id);

        await _courseRepo.UpdateAsync(course, ct);
    }
}