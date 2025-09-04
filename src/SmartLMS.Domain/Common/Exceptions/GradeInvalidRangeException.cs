namespace SmartLMS.Domain.Common.Exceptions;

public class GradeInvalidRangeException : DomainException
{
    public GradeInvalidRangeException() : base("GradeInvalidRange", "Grade must be between 0 and 20") { }
}
