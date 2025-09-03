using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Students.ValueObjects;

public sealed class DateOfBirth : ValueObject
{
    public DateTime Value { get; }

    public DateOfBirth(DateTime value)
    {
		if (value > DateTime.UtcNow)
			throw new DateOfBirthCannotBeInTheFutureException(value);

		Value = value;
	}

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}