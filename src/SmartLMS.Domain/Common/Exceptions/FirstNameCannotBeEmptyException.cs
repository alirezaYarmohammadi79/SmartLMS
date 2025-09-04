namespace SmartLMS.Domain.Common.Exceptions;

public class FirstNameCannotBeEmptyException : DomainException
{
	public FirstNameCannotBeEmptyException()
		: base("FirstNameCannotBeEmpty", "FirstName cannot be empty.") { }
}
