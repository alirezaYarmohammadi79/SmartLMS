namespace SmartLMS.Domain.Common.Exceptions;

public class InvalidEmailFormatException : DomainException
{
	public InvalidEmailFormatException(string email)
		: base($"Email '{email}' format is invalid.") { }
}
