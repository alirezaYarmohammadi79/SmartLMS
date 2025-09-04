using Microsoft.EntityFrameworkCore;
using SmartLMS.Application.Common.Interfaces.ReadRepositories;
using SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;
using SmartLMS.Application.Courses.Query.GetCourseAdminReport;
using SmartLMS.Application.Courses.Query.GetCourseStudents;
using SmartLMS.Application.Courses.Query.GetStudentCourses;
using SmartLMS.Application.Courses.Query.GetTeacherCourses;
using System.Linq;

namespace SmartLMS.Infrastructure.Persistence.Repositories;

public class CourseReadRepository : ICourseReadRepository
{
    private readonly AppDbContext _db;

    public CourseReadRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<CourseAdminReportDto>> GetCourseAdminReportsAsync()
    {
        return await _db.Courses
            .Select(c => new CourseAdminReportDto(
                c.Id,
                c.Title.Value,
                c.Enrollments.Count,
                c.RemainingSeats(),
                c.Enrollments.Average(e => e.Grade) ?? 0
            ))
            .ToListAsync();
    }

    public async Task<IReadOnlyList<AvailableCoursesForStudentDto>> GetAvailableCoursesForStudentAsync()
    {
        var now = DateTime.UtcNow;
        return await _db.Courses.AsNoTracking()
            .Where(c => c.Period.Start <= now && c.Period.End >= now)
            .Join(
                _db.Teachers.AsNoTracking(),
                course => course.TeacherId,
                teacher => teacher.Id,
                (course, teacher) => new AvailableCoursesForStudentDto(
                    course.Id,
                    course.Title.Value,
                    course.TeacherId.Value,
                    teacher.FullName.ToString(),
                    course.Capacity.MaxSeats - course.Enrollments.Count,
                    course.Period.Start,
                    course.Period.End,
                    course.Price.Amount
                )
            )
            .ToListAsync();
    }

    public async Task<IReadOnlyList<StudentCourseDto>> GetStudentCoursesAsync(Guid studentId)
    {
        return await _db.Enrollments
        .AsNoTracking()
        .Where(e => e.StudentId == studentId)
        .Join(
            _db.Courses.AsNoTracking(),
            e => e.CourseId,
            c => c.Id,
            (e, c) => new { e, c }
        )
        .Join(
            _db.Teachers.AsNoTracking(),
            ec => ec.c.TeacherId,
            t => t.Id,
            (ec, t) => new StudentCourseDto(
                ec.c.Id,
                ec.c.Title.Value,
                t.FullName.ToString(),
                ec.e.EnrollmentDate,
                (double?)ec.e.Grade
            )
        )
        .ToListAsync();
    }

    public async Task<IReadOnlyList<TeacherCourseDto>> GetTeacherCoursesAsync(Guid teacherId)
    {
        return await _db.Courses
            .Where(c => c.TeacherId == teacherId)
            .Select(c => new TeacherCourseDto(
                c.Id,
                c.Title.Value,
                c.Enrollments.Count
            ))
            .ToListAsync();
    }

    public async Task<IReadOnlyList<EnrolledStudentsDto>> GetEnrolledStudentsAsync(Guid courseId)
    {
        return await _db.Enrollments
            .Where(e => e.CourseId == courseId)
            .Join(
                _db.Students,
                e => e.StudentId,
                s => s.Id,
                (e, s) => new EnrolledStudentsDto(
                    s.Id,
                    s.FullName.ToString(),
                    s.Email.Value,
                    e.Grade)
            )
            .ToListAsync();
    }
}