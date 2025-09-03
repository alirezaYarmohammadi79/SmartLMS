namespace SmartLMS.Domain.Common.Exceptions;

public class CapacityMustBeGreaterThanZeroException : DomainException
{
	public CapacityMustBeGreaterThanZeroException(int maxSeats)
		: base($"Capacity must be greater than zero. Given: {maxSeats}") { }
}
