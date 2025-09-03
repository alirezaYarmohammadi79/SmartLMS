using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Courses;
using SmartLMS.Infrastructure.Persistence.Exceptions;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
	private readonly AppDbContext _dbContext;

	public CourseRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddAsync(Course course, CancellationToken ct)
	{
		await _dbContext.Courses.AddAsync(course, ct);
		await _dbContext.SaveChangesAsync(ct);
	}

	public async Task UpdateAsync(Course course, CancellationToken ct)
	{
		_dbContext.Courses.Update(course);
		await _dbContext.SaveChangesAsync(ct);
	}

	public async Task DeleteAsync(Guid courseId, CancellationToken ct)
	{
		var course = await _dbContext.Courses.FindAsync([courseId], ct);
		if (course is null) return;

		_dbContext.Courses.Remove(course);
		await _dbContext.SaveChangesAsync(ct);
	}

	public async Task<Course?> GetByIdAsync(Guid courseId, CancellationToken ct)
	{
		return await _dbContext.Courses
			.Include(c => c.Enrollments) 
			.FirstOrDefaultAsync(c => c.Id == courseId, ct);
	}

	public async Task EnrollStudentAsync(Guid courseId, Guid studentId, CancellationToken ct)
	{
		var course = await GetByIdAsync(courseId, ct);
		if (course is null)
			throw new RecordNotFoundException("Course", courseId);

		course.EnrollStudent(studentId);

		await _dbContext.SaveChangesAsync(ct);
	}

	public async Task SetFinalGradeAsync(Guid courseId, Guid studentId, decimal grade, CancellationToken ct)
	{
		var course = await GetByIdAsync(courseId, ct);
		if (course is null)
			throw new RecordNotFoundException("Course", courseId);

		course.AssignGrade(studentId, grade);

		await _dbContext.SaveChangesAsync(ct);
	}
}