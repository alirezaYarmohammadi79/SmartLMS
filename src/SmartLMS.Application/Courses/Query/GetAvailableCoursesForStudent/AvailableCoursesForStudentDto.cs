namespace SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;

public record AvailableCoursesForStudentDto(Guid Id, 
	string Title,
	Guid TeacherId,
	string TeacherName,
	int RemainingSeats,
	DateTime Start,
	DateTime End, 
	decimal Price);
