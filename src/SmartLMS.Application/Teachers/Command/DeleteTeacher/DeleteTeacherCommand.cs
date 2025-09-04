using MediatR;
using SmartLMS.Domain.Common.Exceptions;

namespace SmartLMS.Application.Teachers.Command.DeleteTeacher;

public record DeleteTeacherCommand(Guid TeacherId) : IRequest;
