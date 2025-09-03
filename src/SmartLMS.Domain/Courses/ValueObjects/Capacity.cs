using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.ValueObjects;

public sealed class Capacity : ValueObject
{
    public int MaxSeats { get; }

    public Capacity(int maxSeats)
    {
        if (maxSeats <= 0)
			throw new CapacityMustBeGreaterThanZeroException(maxSeats);

		MaxSeats = maxSeats;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return MaxSeats;
    }
}