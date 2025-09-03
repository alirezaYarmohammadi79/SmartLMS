
namespace SmartLMS.Application.Courses.Query.GetStudentCourses;

public record StudentCourseDto(Guid CourseId,
	string Title,
	string TeacherName,
	DateTime EnrollmentDate,
	double? Grade);
