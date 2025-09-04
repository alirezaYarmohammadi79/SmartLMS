namespace SmartLMS.Domain.Common.Exceptions;

public class PriceCannotBeNegativeException : DomainException
{
	public PriceCannotBeNegativeException(decimal amount)
		: base("PriceCannotBeNegative", $"Price cannot be negative. Given: {amount}") { }
}
