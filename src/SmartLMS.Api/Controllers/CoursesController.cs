using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLMS.Application.Courses.Command.CreateCourse;
using SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;
using SmartLMS.Application.Courses.Query.GetCourse;
using SmartLMS.Application.Courses.Query.GetCourseAdminReport;
using SmartLMS.Application.Courses.Query.GetCourseStudents;
using SmartLMS.Application.Courses.Query.GetEnrolledStudents;
using SmartLMS.Application.Courses.Query.GetStudentCourses;
using SmartLMS.Application.Courses.Query.GetTeacherCourses;
using SmartLMS.Contracts.Courses;

namespace SmartLMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public CoursesController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateCourseRequest request, CancellationToken ct)
	{
		var command = _mapper.Map<CreateCourseCommand>(request);
		var courseId = await _mediator.Send(command, ct);
		return CreatedAtAction(nameof(GetById), new { id = courseId }, courseId);
	}

	//[HttpPut("{id:guid}")]
	//public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCourseRequest request, CancellationToken ct)
	//{
	//	if (id != request.Id) return BadRequest("ID mismatch");

	//	var command = _mapper.Map<UpdateCourseCommand>(request);
	//	await _mediator.Send(command, ct);
	//	return NoContent();
	//}

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
	{
		var query = new GetCourseQuery(id);
		var course = await _mediator.Send(query, ct);
		return course is not null ? Ok(_mapper.Map<CourseResponse>(course)) : NotFound();
	}

	//[HttpGet]
	//public async Task<IActionResult> GetAll(CancellationToken ct)
	//{
	//	var courses = await _mediator.Send(new GetAllCoursesQuery(), ct);
	//	return Ok(courses.Adapt<List<CourseResponse>>());
	//}


	// GET: api/courses/admin-reports
	[HttpGet("admin-reports")]
	public async Task<ActionResult<IReadOnlyList<>>> GetAdminReports()
	{
		var result = await _mediator.Send(new GetCourseAdminReportsQuery());
		return Ok(result);
	}

	// GET: api/courses/student-view
	[HttpGet("student-view")]
	public async Task<ActionResult<IReadOnlyList<>>> GetCoursesForStudent()
	{
		var result = await _mediator
			.Send(new GetAvailableCoursesForStudentQuery());

		return Ok(result);
	}

	// GET: api/courses/student/{studentId}
	[HttpGet("student/{studentId}")]
	public async Task<ActionResult<IReadOnlyList<>>> GetStudentCourses(Guid studentId)
	{
		var result = await _mediator.Send(new GetStudentCoursesQuery(studentId));
		return Ok(result);
	}

	// GET: api/courses/teacher/{teacherId}
	[HttpGet("teacher/{teacherId}")]
	public async Task<ActionResult<IReadOnlyList<>>> GetTeacherCourses(Guid teacherId)
	{
		var result = await _mediator.Send(new GetTeacherCoursesQuery(teacherId));
		return Ok(result);
	}

	// GET: api/courses/{courseId}/students
	[HttpGet("{courseId}/students")]
	public async Task<ActionResult<IReadOnlyList<>>> GetEnrolledStudents(Guid courseId)
	{
		var result = await _mediator.Send(new GetEnrolledStudentsQuery(courseId));
		return Ok(result);
	}
}
