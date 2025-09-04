namespace SmartLMS.Domain.Common.Exceptions;

public class LastNameCannotBeEmptyException : DomainException
{
	public LastNameCannotBeEmptyException()
		: base("LastNameCannotBeEmpty", "LastName cannot be empty.") { }
}
