namespace SmartLMS.Domain.Common.Exceptions;

public class StudentAlreadyEnrolledException : DomainException
{
	public StudentAlreadyEnrolledException(Guid studentId)
		: base("StudentAlreadyEnrolled", $"Student with ID {studentId} is already enrolled.") { }
}
