using MediatR;

namespace SmartLMS.Application.Teachers.Command.CreateTeacher;

public record CreateTeacherCommand(
    string FirstName,
    string LastName,
    string Email,
    string? Bio
) : IRequest<Guid>;
