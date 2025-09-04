using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Price(decimal amount, string currency = "USD")
    {
        if (amount < 0)
            throw new PriceCannotBeNegativeException(amount);
        if (string.IsNullOrWhiteSpace(currency))
            throw new CurrencyMustBeProvidedException();

        Amount = amount;
        Currency = currency;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }



#pragma warning disable CS8618
    public Price() { }
#pragma warning restore CS8618
}