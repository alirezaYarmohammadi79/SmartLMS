namespace SmartLMS.Domain.Common.Exceptions;

public class EmailCannotBeEmptyException : DomainException
{
	public EmailCannotBeEmptyException()
		: base("EmailCannotBeEmpty", "Email cannot be empty.") { }
}
