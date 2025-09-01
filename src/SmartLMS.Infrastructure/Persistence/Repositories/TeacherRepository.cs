using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Teachers;
using System;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _dbContext;

    public TeacherRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Teacher?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task SaveAsync(Teacher teacher)
    {
        _dbContext.Update(teacher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Teachers.AnyAsync(t => t.Id == id);
    }
}
