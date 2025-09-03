using MediatR;

namespace SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;

public record GetAvailableCoursesForStudentQuery() : IRequest<IReadOnlyList<AvailableCoursesForStudentDto>>;
