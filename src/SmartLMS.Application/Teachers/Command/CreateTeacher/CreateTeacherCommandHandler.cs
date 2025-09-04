using MediatR;
using SmartLMS.Domain.Common.ValueObjects;
using SmartLMS.Domain.Teachers;
using SmartLMS.Domain.Teachers.Repository;

namespace SmartLMS.Application.Teachers.Command.CreateTeacher;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
{
    private readonly ITeacherRepository _teacherRepository;

    public CreateTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = Teacher.Create(
            new FullName(request.FirstName, request.LastName),
            new Email(request.Email),
            request.Bio
        );

        await _teacherRepository.AddAsync(teacher, cancellationToken);

        return teacher.Id;
    }
}