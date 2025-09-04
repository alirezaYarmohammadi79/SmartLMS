namespace SmartLMS.Domain.Common.Exceptions;

public class TeacherIdCannotBeEmptyException : DomainException
{
	public TeacherIdCannotBeEmptyException()
		: base("TeacherIdCannotBeEmpty", "TeacherId cannot be empty.") { }
}