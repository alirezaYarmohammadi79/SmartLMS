using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Teachers;
using SmartLMS.Domain.Teachers.Repository;

namespace SmartLMS.Application.Teachers.Query.GetTeacher;

public record GetTeacherQuery(Guid TeacherId) : IRequest<Teacher>;


public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Teacher> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId , cancellationToken);

        if (teacher is null)
            throw new NotFoundException("teacher not found!");

        return teacher;
    }
}