using SmartLMS.Domain.Common.Models;
using SmartLMS.Domain.Common.ValueObjects;
using SmartLMS.Domain.Teachers.Events;

namespace SmartLMS.Domain.Teachers;

public class Teacher : AggregateRoot<Guid>
{
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public string? Bio { get; private set; }

    private Teacher(Guid id, FullName name, Email email, string? bio)
        : base(id)
    {
        FullName = name;
        Email = email;
        Bio = bio;
    }

    // Factory method
    public static Teacher Create(FullName name, Email email, string? bio = null)
    {
        var teacher = new Teacher(Guid.NewGuid(), name, email, bio);
        teacher.AddDomainEvent(new TeacherCreated(teacher));
        return teacher;
    }

    // Update teacher info
    public void UpdateInfo(FullName name, Email email, string? bio = null)
    {
        FullName = name;
        Email = email;
        Bio = bio;
    }

#pragma warning disable CS8618
	private Teacher() { }
#pragma warning restore CS8618
}