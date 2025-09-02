using Microsoft.EntityFrameworkCore;
using SmartLMS.Domain.Students;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
	public Task AddAsync(Student student)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Guid studentId)
	{
		throw new NotImplementedException();
	}

	public Task<Student?> GetByIdAsync(Guid studentId)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Student student)
	{
		throw new NotImplementedException();
	}
}
