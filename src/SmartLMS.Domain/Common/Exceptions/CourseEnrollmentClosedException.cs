namespace SmartLMS.Domain.Common.Exceptions;

public class CourseEnrollmentClosedException : DomainException
{
	public CourseEnrollmentClosedException(DateTime currentTime)
		: base($"Course enrollment is closed at {currentTime}.") { }
}