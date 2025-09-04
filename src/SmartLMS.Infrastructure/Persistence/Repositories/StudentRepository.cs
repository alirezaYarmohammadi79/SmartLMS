using SmartLMS.Domain.Students;
using SmartLMS.Domain.Students.Repository;
using SmartLMS.Infrastructure.Persistence.Exceptions;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
	private readonly AppDbContext _db;

	public StudentRepository(AppDbContext db)
	{
		_db = db;
	}

	// Add a new student
	public async Task AddAsync(Student student, CancellationToken cancellationToken)
	{
		if (student is null) throw new ArgumentNullException(nameof(student));

		await _db.Students.AddAsync(student, cancellationToken);
		await _db.SaveChangesAsync();
	}

	// Update student info
	public async Task UpdateAsync(Student student, CancellationToken cancellationToken)
	{
		if (student is null) throw new ArgumentNullException(nameof(student));

		_db.Students.Update(student);
		await _db.SaveChangesAsync(cancellationToken);
	}

	// Delete a student by ID
	public async Task DeleteAsync(Guid studentId, CancellationToken cancellationToken)
	{
		var student = await _db.Students.FindAsync(studentId, cancellationToken);
		if (student is null) throw new RecordNotFoundException("Student" , studentId);

		_db.Students.Remove(student);
		await _db.SaveChangesAsync();
	}

	// Get student by ID
	public async Task<Student?> GetByIdAsync(Guid studentId , CancellationToken cancellationToken)
	{
		return await _db.Students.FindAsync(studentId, cancellationToken);
	}
}
