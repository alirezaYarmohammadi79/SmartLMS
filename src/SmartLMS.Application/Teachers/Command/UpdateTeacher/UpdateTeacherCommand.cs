using MediatR;
using SmartLMS.Domain.Common.Exceptions;

namespace SmartLMS.Application.Teachers.Command.UpdateTeacher;

public record UpdateTeacherCommand(
    Guid TeacherId,
    string FirstName,
    string LastName,
    string Email,
    string? Bio
) : IRequest;
