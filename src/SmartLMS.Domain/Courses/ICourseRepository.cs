namespace SmartLMS.Domain.Courses;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(Guid id);
    Task SaveAsync(Course course);
    Task<bool> ExistsAsync(Guid id);

}
