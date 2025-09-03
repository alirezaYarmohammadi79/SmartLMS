using MediatR;

namespace SmartLMS.Application.Courses.Query.GetStudentCourses;

public record GetStudentCoursesQuery(Guid StudentId) : IRequest<IReadOnlyList<StudentCourseDto>>;
