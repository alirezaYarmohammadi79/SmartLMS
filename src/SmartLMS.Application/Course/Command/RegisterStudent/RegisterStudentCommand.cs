using MediatR;

namespace SmartLMS.Application.Course.Command.RegisterStudent;

public record RegisterStudentCommand(Guid CourseId, Guid StudentId) : IRequest;

