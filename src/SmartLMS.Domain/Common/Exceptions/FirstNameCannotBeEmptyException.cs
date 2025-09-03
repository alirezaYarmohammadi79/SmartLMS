namespace SmartLMS.Domain.Common.Exceptions;

public class FirstNameCannotBeEmptyException : DomainException
{
	public FirstNameCannotBeEmptyException()
		: base("FirstName cannot be empty.") { }
}
