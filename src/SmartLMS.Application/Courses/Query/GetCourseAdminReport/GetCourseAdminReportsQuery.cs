using MediatR;

namespace SmartLMS.Application.Courses.Query.GetCourseAdminReport;

public record GetCourseAdminReportsQuery() : IRequest<IReadOnlyList<CourseAdminReportDto>>;

