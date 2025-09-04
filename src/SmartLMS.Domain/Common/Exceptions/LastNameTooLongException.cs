namespace SmartLMS.Domain.Common.Exceptions;

public class LastNameTooLongException : DomainException
{
	public LastNameTooLongException(int length)
		: base("LastNameTooLong", $"LastName cannot exceed {length} characters.") { }
}