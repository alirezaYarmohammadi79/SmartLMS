namespace SmartLMS.Domain.Common.Exceptions;

public class PriceCannotBeNegativeException : DomainException
{
	public PriceCannotBeNegativeException(decimal amount)
		: base($"Price cannot be negative. Given: {amount}") { }
}
