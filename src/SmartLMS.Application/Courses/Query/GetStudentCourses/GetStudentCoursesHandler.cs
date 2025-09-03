using MediatR;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;

namespace SmartLMS.Application.Courses.Query.GetStudentCourses;

public class GetStudentCoursesHandler : IRequestHandler<GetStudentCoursesQuery, IReadOnlyList<StudentCourseDto>>
{
	private readonly ICourseReadRepository _repo;

	public GetStudentCoursesHandler(ICourseReadRepository repo) => _repo = repo;

	public async Task<IReadOnlyList<StudentCourseDto>> Handle(GetStudentCoursesQuery request, CancellationToken ct)
		=> await _repo.GetStudentCoursesAsync(request.StudentId);
}