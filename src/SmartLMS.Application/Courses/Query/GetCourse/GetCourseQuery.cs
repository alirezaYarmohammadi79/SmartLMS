using MediatR;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Application.Courses.Query.GetCourse;

public record GetCourseQuery(Guid CourseId) : IRequest<Course>;
