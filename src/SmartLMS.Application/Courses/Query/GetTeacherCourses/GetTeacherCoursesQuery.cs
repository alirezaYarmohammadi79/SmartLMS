using MediatR;

namespace SmartLMS.Application.Courses.Query.GetTeacherCourses;

public record GetTeacherCoursesQuery(Guid TeacherId) : IRequest<IReadOnlyList<TeacherCourseDto>>;
