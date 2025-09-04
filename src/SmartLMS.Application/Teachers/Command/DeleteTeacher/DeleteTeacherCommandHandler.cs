using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Teachers.Repository;

namespace SmartLMS.Application.Teachers.Command.DeleteTeacher;

public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
{
    private readonly ITeacherRepository _teacherRepository;

    public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId, cancellationToken);

        if (teacher is null)
            throw new NotFoundException($"Teacher with id {request.TeacherId} not found");

        await _teacherRepository.DeleteAsync(request.TeacherId, cancellationToken);
    }
}