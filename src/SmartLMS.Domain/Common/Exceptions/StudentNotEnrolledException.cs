namespace SmartLMS.Domain.Common.Exceptions;

public class StudentNotEnrolledException : DomainException
{
	public StudentNotEnrolledException(Guid studentId)
		: base("StudentNotEnrolled", $"Student with ID {studentId} is not enrolled in the course.") { }
}
