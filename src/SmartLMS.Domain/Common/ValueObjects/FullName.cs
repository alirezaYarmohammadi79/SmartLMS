using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Common.ValueObjects;

public sealed class FullName : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private FullName() { }

    public FullName(string firstName, string lastName)
    {
		if (string.IsNullOrWhiteSpace(firstName))
			throw new FirstNameCannotBeEmptyException();

		if (string.IsNullOrWhiteSpace(lastName))
			throw new LastNameCannotBeEmptyException();

		if (firstName.Length > 100)
			throw new FirstNameTooLongException(firstName.Length);

		if (lastName.Length > 100)
			throw new LastNameTooLongException(lastName.Length);

		FirstName = firstName;
		LastName = lastName;
	}

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }

    public override string ToString() => $"{FirstName} {LastName}";
}