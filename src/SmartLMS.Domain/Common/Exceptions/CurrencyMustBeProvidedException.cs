namespace SmartLMS.Domain.Common.Exceptions;

public class CurrencyMustBeProvidedException : DomainException
{
	public CurrencyMustBeProvidedException()
		: base("Currency must be provided.") { }
}
