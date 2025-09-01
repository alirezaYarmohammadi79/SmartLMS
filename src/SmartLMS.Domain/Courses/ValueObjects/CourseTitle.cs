using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.ValueObjects;

public sealed class CourseTitle : ValueObject
{
    public string Value { get; }

    public CourseTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Course title cannot be empty.");

        if (value.Length > 200)
            throw new DomainException("Course title is too long.");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}