using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Teachers.Events;

public record TeacherCreated (Teacher Teacher) : IDomainEvent;  

