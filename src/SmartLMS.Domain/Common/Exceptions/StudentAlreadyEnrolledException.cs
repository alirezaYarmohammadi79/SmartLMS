namespace SmartLMS.Domain.Common.Exceptions;

public class StudentAlreadyEnrolledException : DomainException
{
	public StudentAlreadyEnrolledException(Guid studentId)
		: base($"Student with ID {studentId} is already enrolled.") { }
}
