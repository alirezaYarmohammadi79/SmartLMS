using MediatR;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;

namespace SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;

public class GetAvailableCoursesForStudentHandler : IRequestHandler<GetAvailableCoursesForStudentQuery, IReadOnlyList<AvailableCoursesForStudentDto>>
{
	private readonly ICourseReadRepository _repo;

	public GetAvailableCoursesForStudentHandler(ICourseReadRepository repo) => _repo = repo;

	public async Task<IReadOnlyList<AvailableCoursesForStudentDto>> Handle(GetAvailableCoursesForStudentQuery request, CancellationToken ct)
		=> await _repo.GetAvailableCoursesForStudentAsync();
}