using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.Entities;

public class Enrollment : Entity<Guid>
{
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public DateTime EnrollmentDate { get; private set; }
    public decimal? Grade { get; private set; }

    public Enrollment(Guid studentId , Guid courseId, DateTime enrollmentDate)
    {
        Id = Guid.NewGuid(); 
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = enrollmentDate;
    }

    public void SetGrade(decimal grade)
    {
        if (grade <= 0 || grade >= 20)
            throw new DomainException("Grade must be between 0 and 20");

        Grade = grade;
    }

#pragma warning disable CS8618
	private Enrollment() { }
#pragma warning restore CS8618
}