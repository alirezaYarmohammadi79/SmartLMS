namespace SmartLMS.Domain.Common.Exceptions;

public class CurrencyMustBeProvidedException : DomainException
{
	public CurrencyMustBeProvidedException()
		: base("CurrencyMustBeProvided", "Currency must be provided.") { }
}
