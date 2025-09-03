namespace SmartLMS.Domain.Common.Exceptions;

public class TeacherIdCannotBeEmptyException : DomainException
{
	public TeacherIdCannotBeEmptyException()
		: base("TeacherId cannot be empty.") { }
}