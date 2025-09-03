namespace SmartLMS.Domain.Common.Exceptions;

public class CourseTitleTooLongException : DomainException
{
	public CourseTitleTooLongException(int length)
		: base($"Course title is too long. Length: {length}") { }
}
