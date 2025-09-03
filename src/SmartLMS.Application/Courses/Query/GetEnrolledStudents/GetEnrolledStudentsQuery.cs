using MediatR;
using SmartLMS.Application.Courses.Query.GetCourseStudents;

namespace SmartLMS.Application.Courses.Query.GetEnrolledStudents;

public record GetEnrolledStudentsQuery(Guid CourseId) : IRequest<IReadOnlyList<EnrolledStudentsDto>>;
