using MediatR;
using SmartLMS.Domain.Common.ValueObjects;
using SmartLMS.Domain.Students.ValueObjects;
using SmartLMS.Domain.Students;
using SmartLMS.Domain.Students.Repository;

namespace SmartLMS.Application.Students.Command.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentRepository _studentRepository;

    public CreateStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var fullName = new FullName(request.FirstName, request.LastName);
        var email = new Email(request.Email);
        var dob = new DateOfBirth(request.DateOfBirth);

        var student = Student.Create(fullName, email, dob);

        await _studentRepository.AddAsync(student, cancellationToken);
        return student.Id;
    }
}