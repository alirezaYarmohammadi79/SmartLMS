using MediatR;
using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Students;
using SmartLMS.Domain.Students.Repository;

namespace SmartLMS.Application.Students.Query.GetStudent;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.StudentId, cancellationToken)
                      ?? throw new NotFoundException("Student not found");

        return student;   
    }
}
