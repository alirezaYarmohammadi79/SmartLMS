using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.Events;

public record StudentRemoved (Guid courseId,Guid StudentId) : IDomainEvent;
