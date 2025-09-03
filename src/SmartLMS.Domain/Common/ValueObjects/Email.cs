using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;
using System.Text.RegularExpressions;

namespace SmartLMS.Domain.Common.ValueObjects;

public sealed class Email : ValueObject
{
    public string Value { get; }

	public Email(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
			throw new EmailCannotBeEmptyException();

		var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
		if (!regex.IsMatch(value))
			throw new InvalidEmailFormatException(value);

		Value = value;
	}

	protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}