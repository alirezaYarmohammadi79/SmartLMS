namespace SmartLMS.Domain.Common.Exceptions;

public class CannotAssignGradeBeforeCourseEndsException : DomainException
{
	public CannotAssignGradeBeforeCourseEndsException(DateTime currentTime, DateTime courseEnd)
		: base("CannotAssignGradeBeforeCourseEnds", $"Cannot assign grade at {currentTime} because the course ends at {courseEnd}.") { }
}