using MediatR;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;

namespace SmartLMS.Application.Courses.Query.GetTeacherCourses;
public class GetTeacherCoursesHandler : IRequestHandler<GetTeacherCoursesQuery, IReadOnlyList<TeacherCourseDto>>
{
	private readonly ICourseReadRepository _repo;

	public GetTeacherCoursesHandler(ICourseReadRepository repo) => _repo = repo;

	public async Task<IReadOnlyList<TeacherCourseDto>> Handle(GetTeacherCoursesQuery request, CancellationToken ct)
		=> await _repo.GetTeacherCoursesAsync(request.TeacherId);
}