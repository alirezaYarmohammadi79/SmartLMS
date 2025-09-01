using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Students.Events;

public record StudentCreated(Student Student): IDomainEvent;

