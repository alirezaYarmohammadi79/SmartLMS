namespace SmartLMS.Domain.Common.Exceptions;

public class CourseTitleCannotBeEmptyException : DomainException
{
	public CourseTitleCannotBeEmptyException()
		: base("CourseTitleCannotBeEmpty", "Course title cannot be empty.") { }
}
