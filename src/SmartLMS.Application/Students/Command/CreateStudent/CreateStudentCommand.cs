using MediatR;

namespace SmartLMS.Application.Students.Command.CreateStudent;

// Create student
public record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email,
    DateTime? DateOfBirth
) : IRequest<Guid>;
