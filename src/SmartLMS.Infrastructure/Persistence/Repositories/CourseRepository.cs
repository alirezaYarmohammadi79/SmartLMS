using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Courses
            .Include(c => c.Enrollments)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveAsync(Course course)
    {
        _dbContext.Update(course);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Courses.AnyAsync(c => c.Id == id);
    }
}
