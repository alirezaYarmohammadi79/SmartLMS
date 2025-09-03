namespace SmartLMS.Domain.Common.Exceptions;

public class DateOfBirthCannotBeInTheFutureException : DomainException
{
	public DateOfBirthCannotBeInTheFutureException(DateTime date)
		: base($"Date of birth '{date:yyyy-MM-dd}' cannot be in the future.") { }
}