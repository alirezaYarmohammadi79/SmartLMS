using MediatR;

namespace SmartLMS.Application.Courses.Command.AssignTeacher;

public record AssignTeacherCommand(Guid CourseId, Guid TeacherId) : IRequest;
