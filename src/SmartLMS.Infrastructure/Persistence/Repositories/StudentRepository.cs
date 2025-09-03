using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Students;
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
	public async Task AddAsync(Student student)
	{
		if (student is null) throw new ArgumentNullException(nameof(student));

		await _db.Students.AddAsync(student);
		await _db.SaveChangesAsync();
	}

	// Update student info
	public async Task UpdateAsync(Student student)
	{
		if (student is null) throw new ArgumentNullException(nameof(student));

		_db.Students.Update(student);
		await _db.SaveChangesAsync();
	}

	// Delete a student by ID
	public async Task DeleteAsync(Guid studentId)
	{
		var student = await _db.Students.FindAsync(studentId);
		if (student is null) throw new RecordNotFoundException("Student" , studentId);

		_db.Students.Remove(student);
		await _db.SaveChangesAsync();
	}

	// Get student by ID
	public async Task<Student?> GetByIdAsync(Guid studentId)
	{
		return await _db.Students.FindAsync(studentId);
	}
}
