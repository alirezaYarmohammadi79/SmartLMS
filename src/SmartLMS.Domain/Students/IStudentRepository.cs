namespace SmartLMS.Domain.Students;

public interface IStudentRepository
{
	// Create a new student
	Task AddAsync(Student student);

	// Update student info
	Task UpdateAsync(Student student);

	// Delete a student
	Task DeleteAsync(Guid studentId);

	// Retrieve a student aggregate by ID
	Task<Student?> GetByIdAsync(Guid studentId);
}
