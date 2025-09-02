namespace SmartLMS.Application.Course.Query.GetCourseStudents;

public record CourseStudentsDto(Guid StudentId,
	string StudentName,
	string StudentEmail,
	double? Grade);

