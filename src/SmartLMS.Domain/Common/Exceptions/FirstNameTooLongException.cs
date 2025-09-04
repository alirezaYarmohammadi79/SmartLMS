namespace SmartLMS.Domain.Common.Exceptions;

public class FirstNameTooLongException : DomainException
{
	public FirstNameTooLongException(int length)
		: base("FirstNameTooLong", $"FirstName cannot exceed {length} characters.") { }
}
