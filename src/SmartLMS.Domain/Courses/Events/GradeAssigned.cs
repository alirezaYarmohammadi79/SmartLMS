using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.Events;

public record GradeAssigned(Guid CourseId , Guid StudentId , decimal Grade) : IDomainEvent;