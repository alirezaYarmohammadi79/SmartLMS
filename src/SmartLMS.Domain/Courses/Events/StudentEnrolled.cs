using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.Events;

public record StudentEnrolled (Guid courseId, Guid StudentId) : IDomainEvent;
