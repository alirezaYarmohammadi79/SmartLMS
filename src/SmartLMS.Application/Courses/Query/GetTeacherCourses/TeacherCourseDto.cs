namespace SmartLMS.Application.Courses.Query.GetTeacherCourses;

public record TeacherCourseDto (Guid CourseId,
	string CourseTitle,
	int EnrolledCount);

