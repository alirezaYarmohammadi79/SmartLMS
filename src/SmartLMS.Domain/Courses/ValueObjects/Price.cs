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
            throw new DomainException("Price cannot be negative.");
        if (string.IsNullOrWhiteSpace(currency))
            throw new DomainException("Currency must be provided.");

        Amount = amount;
        Currency = currency;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}