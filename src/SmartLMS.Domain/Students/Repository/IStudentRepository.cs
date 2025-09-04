namespace SmartLMS.Domain.Students.Repository;

public interface IStudentRepository
{
	// Create a new student
	Task AddAsync(Student student, CancellationToken cancellationToken);

	// Update student info
	Task UpdateAsync(Student student, CancellationToken cancellationToken);

	// Delete a student
	Task DeleteAsync(Guid studentId, CancellationToken cancellationToken);

	// Retrieve a student aggregate by ID
	Task<Student?> GetByIdAsync(Guid studentId, CancellationToken cancellationToken);
}
