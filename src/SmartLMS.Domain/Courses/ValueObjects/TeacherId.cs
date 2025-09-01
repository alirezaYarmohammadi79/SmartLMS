using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.ValueObjects;

public sealed class TeacherId : ValueObject
{
    public Guid Value { get; }

    public TeacherId(Guid value)
    {
        if (value == Guid.Empty) throw new DomainException("TeacherId cannot be empty");
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}