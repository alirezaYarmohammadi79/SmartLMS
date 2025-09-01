namespace SmartLMS.Domain.Teachers;

public interface ITeacherRepository
{
    Task<Teacher?> GetByIdAsync(Guid id);
    Task SaveAsync(Teacher teacher);
    Task<bool> ExistsAsync(Guid id);
}
