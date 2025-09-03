using MediatR;

namespace SmartLMS.Application.Courses.Command.RegisterStudent;

public record RegisterStudentCommand(Guid CourseId, Guid StudentId) : IRequest;

