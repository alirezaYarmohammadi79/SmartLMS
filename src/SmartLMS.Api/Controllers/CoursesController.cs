using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLMS.Application.Courses.Command.AssignTeacher;
using SmartLMS.Application.Courses.Command.CreateCourse;
using SmartLMS.Application.Courses.Command.RegisterStudent;
using SmartLMS.Application.Courses.Command.SetFinalGradeCommand;
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
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateCourseCommand>(request);
        var courseId = await _mediator.Send(command, cancellationToken);
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
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCourseQuery(id);
        var course = await _mediator.Send(query, cancellationToken);
        return course is not null ? Ok(_mapper.Map<CourseResponse>(course)) : NotFound();
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(
       RegisterStudentRequest request,
       CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegisterStudentCommand>(request);
        await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<RegisterStudentResponse>(command);
        return Ok(response);
    }

    [HttpPost("SetFinalGrade")]
    public async Task<ActionResult<SetFinalGradeResponse>> SetFinalGrade(SetFinalGradeRequest request,CancellationToken cancellationToken)
    {
        var command = _mapper.Map<SetFinalGradeCommand>(request);
        await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<SetFinalGradeResponse>(command);
        return Ok(response);
    }


    [HttpPost("AssignTeacher")]
    public async Task<IActionResult> AssignTeacher(AssignTeacherRequest request , CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AssignTeacherCommand>(request);
        await _mediator.Send(command , cancellationToken);
        var response = _mapper.Map<AssignTeacherResponse>(command);
        return Ok(response);
    }


    [HttpGet("AdminReports")]
    public async Task<ActionResult<IReadOnlyList<CourseAdminReportResponse>>> GetAdminReports()
    {
        var result = await _mediator.Send(new GetCourseAdminReportsQuery());
        return Ok(_mapper.Map<List<CourseAdminReportResponse>>(result));
    }

    [HttpGet("AvailableCoursesForStudent")]
    public async Task<ActionResult<IReadOnlyList<AvailableCoursesForStudentResponse>>> GetCoursesForStudent()
    {
        var result = await _mediator
            .Send(new GetAvailableCoursesForStudentQuery());

        return Ok(_mapper.Map<List<AvailableCoursesForStudentResponse>>(result));
    }

    [HttpGet("StudentCourses/{studentId}")]
    public async Task<ActionResult<IReadOnlyList<StudentCourseResponse>>> GetStudentCourses(Guid studentId)
    {
        var result = await _mediator.Send(new GetStudentCoursesQuery(studentId));
        return Ok(_mapper.Map<List<StudentCourseResponse>>(result));
    }

    [HttpGet("TeacherCourses/{teacherId}")]
    public async Task<ActionResult<IReadOnlyList<TeacherCourseResponse>>> GetTeacherCourses(Guid teacherId)
    {
        IReadOnlyList<TeacherCourseDto>? result = await _mediator.Send(new GetTeacherCoursesQuery(teacherId));
        return Ok(_mapper.Map<List<TeacherCourseResponse>>(result));
    }

    [HttpGet("{courseId}/EnrolledStudents")]
    public async Task<ActionResult<IReadOnlyList<EnrolledStudentsResponse>>> GetEnrolledStudents(Guid courseId)
    {
        var result = await _mediator.Send(new GetEnrolledStudentsQuery(courseId));
        return Ok(_mapper.Map<List<EnrolledStudentsResponse>>(result));
    }
}
