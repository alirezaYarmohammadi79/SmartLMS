using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.Events;

public record CourseCreated(Course Course) : IDomainEvent;