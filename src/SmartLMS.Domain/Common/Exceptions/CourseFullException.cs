namespace SmartLMS.Domain.Common.Exceptions;

public class CourseFullException : DomainException
{
	public CourseFullException(int capacity)
		: base("CourseFull", $"Course is full. Maximum capacity is {capacity}.") { }
}
