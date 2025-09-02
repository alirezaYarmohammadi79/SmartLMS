namespace SmartLMS.Domain.Courses;

public interface ICourseRepository
{
	// Create a new course
	Task AddAsync(Course course , CancellationToken ct);

	// Update course details (title, description, capacity, dates, fee, etc.)
	Task UpdateAsync(Course course , CancellationToken ct);

	// Delete a course
	Task DeleteAsync(Guid courseId , CancellationToken ct);

	// Retrieve a course aggregate by ID (for domain operations)
	Task<Course?> GetByIdAsync(Guid courseId, CancellationToken ct);

	// Enroll a student in a course (domain logic ensures capacity/date constraints)
	Task EnrollStudentAsync(Guid courseId, Guid studentId, CancellationToken ct);

	// Assign final grade for a student in a course
	Task SetFinalGradeAsync(Guid courseId, Guid studentId, decimal grade , CancellationToken ct);
}