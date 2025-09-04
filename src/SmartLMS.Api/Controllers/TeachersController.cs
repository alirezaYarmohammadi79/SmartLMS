using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartLMS.Application.Teachers.Command.CreateTeacher;
using SmartLMS.Application.Teachers.Query.GetTeacher;
using SmartLMS.Contracts.Teachers;

namespace SmartLMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public TeachersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateTeacherCommand>(request);
        var teacherId = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id = teacherId }, teacherId);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        GetTeacherQuery? query = new GetTeacherQuery(id);
        var teacher = await _mediator.Send(query, ct);
        return teacher is not null ? Ok(_mapper.Map<TeacherResponse>(teacher)) : NotFound();
    }
}
