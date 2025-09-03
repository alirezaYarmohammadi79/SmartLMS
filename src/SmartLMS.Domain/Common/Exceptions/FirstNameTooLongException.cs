namespace SmartLMS.Domain.Common.Exceptions;

public class FirstNameTooLongException : DomainException
{
	public FirstNameTooLongException(int length)
		: base($"FirstName cannot exceed {length} characters.") { }
}
