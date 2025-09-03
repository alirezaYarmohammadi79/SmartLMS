namespace SmartLMS.Domain.Common.Exceptions;

public class CourseTitleCannotBeEmptyException : DomainException
{
	public CourseTitleCannotBeEmptyException()
		: base("Course title cannot be empty.") { }
}
