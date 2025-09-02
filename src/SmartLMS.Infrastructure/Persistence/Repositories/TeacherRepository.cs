using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Teachers;
using System;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
	public Task AddAsync(Teacher teacher)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Guid teacherId)
	{
		throw new NotImplementedException();
	}

	public Task<Teacher?> GetByIdAsync(Guid teacherId)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Teacher teacher)
	{
		throw new NotImplementedException();
	}
}
