using SmartLMS.Domain.Teachers;
using SmartLMS.Domain.Teachers.Repository;
using SmartLMS.Infrastructure.Persistence.Exceptions;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
	private readonly AppDbContext _db;

	public TeacherRepository(AppDbContext db)
	{
		_db = db;
	}

	// Add a new teacher
	public async Task AddAsync(Teacher teacher, CancellationToken cancellationToken)
	{
		if (teacher is null) throw new ArgumentNullException(nameof(teacher));

		await _db.Teachers.AddAsync(teacher,cancellationToken);
		await _db.SaveChangesAsync(cancellationToken);
	}

	// Update teacher info
	public async Task UpdateAsync(Teacher teacher, CancellationToken cancellationToken)
	{
		if (teacher is null) throw new ArgumentNullException(nameof(teacher));

		_db.Teachers.Update(teacher);
		await _db.SaveChangesAsync(cancellationToken);
	}

	// Delete a teacher by ID
	public async Task DeleteAsync(Guid teacherId, CancellationToken cancellationToken)
	{
		var teacher = await _db.Teachers.FindAsync(teacherId, cancellationToken);
		if (teacher is null) throw new RecordNotFoundException("Teacher" , teacherId);

		_db.Teachers.Remove(teacher);
		await _db.SaveChangesAsync(cancellationToken);
	}

	// Get teacher by ID
	public async Task<Teacher?> GetByIdAsync(Guid teacherId, CancellationToken cancellationToken)
	{
		return await _db.Teachers.FindAsync(teacherId, cancellationToken);
	}
}

