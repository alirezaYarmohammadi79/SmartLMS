namespace SmartLMS.Domain.Common.Exceptions;

public class CapacityMustBeGreaterThanZeroException : DomainException
{
	public CapacityMustBeGreaterThanZeroException(int maxSeats)
		: base("CapacityMustBeGreaterThanZero", $"Capacity must be greater than zero. Given: {maxSeats}") { }
}
