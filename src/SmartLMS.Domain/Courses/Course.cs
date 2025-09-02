using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;
using SmartLMS.Domain.Courses.Entities;
using SmartLMS.Domain.Courses.Events;
using SmartLMS.Domain.Courses.ValueObjects;

namespace SmartLMS.Domain.Courses;

public class Course : AggregateRoot<Guid>
{
    private readonly List<Enrollment> _enrollments = new();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

    public CourseTitle Title { get; private set; }
    public string Description { get; private set; }
    public DateRange Period { get; private set; }
    public Capacity Capacity { get; private set; }
    public Price Price { get; private set; }
    public TeacherId TeacherId { get; private set; }

    private Course(Guid id,
        CourseTitle title,
        string description,
        DateRange period,
        Capacity capacity,
        Price price,
        TeacherId teacherId)
        : base(id)
    {
        Title = title;
        Description = description;
        Period = period;
        Capacity = capacity;
        Price = price;
        TeacherId = teacherId;
    }

    public static Course Create(CourseTitle title,
        string description,
        DateRange period,
        Capacity capacity,
        Price price,
        TeacherId teacherId)
    {
        var course = new Course(
            Guid.NewGuid(),
            title ,
            description,
            period,
            capacity,
            price,
            teacherId);

        course.AddDomainEvent(new CourseCreated(course));

        return course;
    }

    public void AssignTeacher(TeacherId teacherId)
    {
        TeacherId = teacherId;
    }

    public void EnrollStudent(Guid studentId)
    {
        if (_enrollments.Count >= Capacity.MaxSeats)
            throw new DomainException("Course is full");

        if (_enrollments.Any(e => e.StudentId == studentId))
            throw new DomainException("Student already enrolled");

        if (!Period.IsWithin(DateTime.UtcNow))
            throw new DomainException("Course enrollment closed");

        var enrollment = new Enrollment(studentId , Id, DateTime.UtcNow);
        _enrollments.Add(enrollment);

        AddDomainEvent(new StudentEnrolled(Id, studentId));
    }

    public void RemoveStudent(Guid studentId)
    {
        var enrollment = _enrollments.FirstOrDefault(e => e.StudentId == studentId);
        if (enrollment is null) throw new DomainException("Student not enrolled");

        _enrollments.Remove(enrollment);
        AddDomainEvent(new StudentRemoved(Id, studentId));
    }

    public void AssignGrade(Guid studentId, decimal grade)
    {
        if (DateTime.UtcNow < Period.End) throw new DomainException("Cannot assign grade before course ends");

        var enrollment = _enrollments.FirstOrDefault(e => e.StudentId == studentId);
        if (enrollment is null) throw new DomainException("Student not enrolled");

        enrollment.SetGrade(grade);
        AddDomainEvent(new GradeAssigned(Id, studentId, grade));
    }

    public int RemainingSeats() => Capacity.MaxSeats - _enrollments.Count;

#pragma warning disable CS8618 
    public Course()
    { 
    }
#pragma warning restore CS8618 
}
