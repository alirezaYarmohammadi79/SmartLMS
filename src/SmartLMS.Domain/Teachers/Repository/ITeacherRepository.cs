namespace SmartLMS.Domain.Teachers.Repository;

public interface ITeacherRepository
{
	// Create a new teacher
	Task AddAsync(Teacher teacher, CancellationToken cancellationToken);

	// Update teacher info
	Task UpdateAsync(Teacher teacher, CancellationToken cancellationToken);

	// Delete a teacher
	Task DeleteAsync(Guid teacherId, CancellationToken cancellationToken);

	// Retrieve a teacher aggregate by ID
	Task<Teacher?> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken);
}
