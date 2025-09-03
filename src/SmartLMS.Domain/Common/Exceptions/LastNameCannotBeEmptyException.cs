namespace SmartLMS.Domain.Common.Exceptions;

public class LastNameCannotBeEmptyException : DomainException
{
	public LastNameCannotBeEmptyException()
		: base("LastName cannot be empty.") { }
}
