using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Teachers;
using SmartLMS.Infrastructure.Persistence.Exceptions;
using System;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
	private readonly AppDbContext _db;

	public TeacherRepository(AppDbContext db)
	{
		_db = db;
	}

	// Add a new teacher
	public async Task AddAsync(Teacher teacher)
	{
		if (teacher is null) throw new ArgumentNullException(nameof(teacher));

		await _db.Teachers.AddAsync(teacher);
		await _db.SaveChangesAsync();
	}

	// Update teacher info
	public async Task UpdateAsync(Teacher teacher)
	{
		if (teacher is null) throw new ArgumentNullException(nameof(teacher));

		_db.Teachers.Update(teacher);
		await _db.SaveChangesAsync();
	}

	// Delete a teacher by ID
	public async Task DeleteAsync(Guid teacherId)
	{
		var teacher = await _db.Teachers.FindAsync(teacherId);
		if (teacher is null) throw new RecordNotFoundException("Teacher" , teacherId);

		_db.Teachers.Remove(teacher);
		await _db.SaveChangesAsync();
	}

	// Get teacher by ID
	public async Task<Teacher?> GetByIdAsync(Guid teacherId)
	{
		return await _db.Teachers.FindAsync(teacherId);
	}
}

