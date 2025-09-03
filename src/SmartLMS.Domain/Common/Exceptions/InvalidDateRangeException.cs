namespace SmartLMS.Domain.Common.Exceptions;

public class InvalidDateRangeException : DomainException
{
	public InvalidDateRangeException(DateTime start, DateTime end)
		: base($"Start date {start} must be before end date {end}.") { }
}
