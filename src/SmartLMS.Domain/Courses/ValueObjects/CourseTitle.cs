using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Common.Models;

namespace SmartLMS.Domain.Courses.ValueObjects;

public sealed class CourseTitle : ValueObject
{
    public string Value { get; }

    public CourseTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new CourseTitleCannotBeEmptyException();

        if (value.Length > 200)
            throw new CourseTitleTooLongException(value.Length);

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}