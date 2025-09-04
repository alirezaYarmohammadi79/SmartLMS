namespace SmartLMS.Domain.Courses.Repository;

public interface ICourseRepository
{
    // Create a new course
    Task AddAsync(Course course, CancellationToken ct);

    // Update course details (title, description, capacity, dates, fee, etc.)
    Task UpdateAsync(Course course, CancellationToken ct);

    // Delete a course
    Task DeleteAsync(Guid courseId, CancellationToken ct);

    // Retrieve a course aggregate by ID (for domain operations)
    Task<Course?> GetByIdAsync(Guid courseId, CancellationToken ct);
}