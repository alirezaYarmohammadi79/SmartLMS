using MediatR;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Students;

namespace SmartLMS.Application.Students.Query.GetStudent;

public record GetStudentByIdQuery(Guid StudentId) : IRequest<Student>;
