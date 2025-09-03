using MediatR;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;

namespace SmartLMS.Application.Courses.Query.GetCourseAdminReport;

public class GetCourseAdminReportsHandler : IRequestHandler<GetCourseAdminReportsQuery, IReadOnlyList<CourseAdminReportDto>>
{
	private readonly ICourseReadRepository _repo;

	public GetCourseAdminReportsHandler(ICourseReadRepository repo) => _repo = repo;

	public async Task<IReadOnlyList<CourseAdminReportDto>> Handle(GetCourseAdminReportsQuery request, CancellationToken ct)
		=> await _repo.GetCourseAdminReportsAsync();
}
