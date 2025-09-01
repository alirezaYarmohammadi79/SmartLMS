using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Teachers.ValueObjects;

public sealed class FullName : ValueObject
{
    public string Value { get; }

    public FullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Full name cannot be empty");

        if (value.Length > 100)
            throw new DomainException("Full name too long");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}