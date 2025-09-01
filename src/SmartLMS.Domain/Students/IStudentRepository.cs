namespace SmartLMS.Domain.Students;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(Guid id);
    Task SaveAsync(Student student);
    Task<bool> ExistsAsync(Guid id);
}
