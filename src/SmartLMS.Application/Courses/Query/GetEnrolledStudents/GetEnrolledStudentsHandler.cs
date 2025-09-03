using MediatR;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;
using SmartLMS.Application.Courses.Query.GetCourseStudents;

namespace SmartLMS.Application.Courses.Query.GetEnrolledStudents;

public class GetEnrolledStudentsHandler : IRequestHandler<GetEnrolledStudentsQuery, IReadOnlyList<EnrolledStudentsDto>>
{
	private readonly ICourseReadRepository _repo;

	public GetEnrolledStudentsHandler(ICourseReadRepository repo) => _repo = repo;

	public async Task<IReadOnlyList<EnrolledStudentsDto>> Handle(GetEnrolledStudentsQuery request, CancellationToken ct)
		=> await _repo.GetEnrolledStudentsAsync(request.CourseId);
}
