namespace SmartLMS.Application.Courses.Query.GetCourseStudents;

public record EnrolledStudentsDto(
	Guid StudentId,
	string StudentName,
	string StudentEmail,
	decimal? Grade);

