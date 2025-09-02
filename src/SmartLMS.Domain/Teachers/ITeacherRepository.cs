namespace SmartLMS.Domain.Teachers;

public interface ITeacherRepository
{
	// Create a new teacher
	Task AddAsync(Teacher teacher);

	// Update teacher info
	Task UpdateAsync(Teacher teacher);

	// Delete a teacher
	Task DeleteAsync(Guid teacherId);

	// Retrieve a teacher aggregate by ID
	Task<Teacher?> GetByIdAsync(Guid teacherId);
}
