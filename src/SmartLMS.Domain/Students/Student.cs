using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;
using SmartLMS.Domain.Students.Enum;
using SmartLMS.Domain.Students.Events;
using SmartLMS.Domain.Students.ValueObjects;
using SmartLMS.Domain.Teachers.ValueObjects;

namespace SmartLMS.Domain.Students;

public class Student : AggregateRoot<Guid>
{
    public FullName Name { get; private set; }
    public Email Email { get; private set; }
    public DateOfBirth? DOB { get; private set; }
    public StudentStatus Status { get; private set; } 

    private Student(Guid id, 
        FullName name, 
        Email email,
        DateOfBirth? dob = null,
        StudentStatus status = StudentStatus.Active)
        : base(id)
    {
        Name = name;
        Email = email;
        DOB = dob;
        Status = status;
    }

    public static Student Create(FullName name, Email email, DateOfBirth? dob = null)
    {
        var student = new Student(Guid.NewGuid(), name, email, dob);
        student.AddDomainEvent(new StudentCreated(student));
        return student;
    }

    public void UpdateInfo(FullName name, Email email, DateOfBirth? dob = null)
    {
        Name = name;
        Email = email;
        DOB = dob;
    }

    public void ChangeStatus(StudentStatus newStatus) => Status = newStatus;
}