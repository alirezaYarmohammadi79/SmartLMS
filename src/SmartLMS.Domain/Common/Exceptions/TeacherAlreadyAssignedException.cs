namespace SmartLMS.Domain.Common.Exceptions;

public class TeacherAlreadyAssignedException : DomainException
{
    public TeacherAlreadyAssignedException() : base("TeacherAlreadyAssigned", "This teacher is already assigned.")
    {
    }
}
