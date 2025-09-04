using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Common.ValueObjects;
using SmartLMS.Domain.Teachers.Repository;

namespace SmartLMS.Application.Teachers.Command.UpdateTeacher;

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
{
    private readonly ITeacherRepository _teacherRepository;

    public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId, cancellationToken);

        if (teacher is null)
            throw new NotFoundException($"Teacher with id {request.TeacherId} not found");

        teacher.UpdateInfo(
            new FullName(request.FirstName, request.LastName),
            new Email(request.Email),
            request.Bio
        );

        await _teacherRepository.UpdateAsync(teacher, cancellationToken);
    }
}