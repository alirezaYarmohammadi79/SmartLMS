namespace SmartLMS.Domain.Common.Exceptions;

public class EmailCannotBeEmptyException : DomainException
{
	public EmailCannotBeEmptyException()
		: base("Email cannot be empty.") { }
}
