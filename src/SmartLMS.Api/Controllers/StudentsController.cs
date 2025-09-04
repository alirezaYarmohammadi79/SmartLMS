using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartLMS.Application.Students.Command.CreateStudent;
using SmartLMS.Application.Students.Query.GetStudent;
using SmartLMS.Contracts.Students;

namespace SmartLMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public StudentsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateStudentCommand>(request);
        var studentId = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id = studentId }, studentId);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var query = new GetStudentByIdQuery(id);
        var student = await _mediator.Send(query, ct);
        return student is not null ? Ok(_mapper.Map<StudentResponse>(student)) : NotFound();
    }
}
