using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Students;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task SaveAsync(Student student)
    {
        _dbContext.Update(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Students.AnyAsync(s => s.Id == id);
    }
}
