namespace SmartLMS.Contracts.Courses;

public record CreateCourseRequest(
	string Title,
	string Description,
	DateTime StartDate,
	DateTime EndDate,
	int Capacity,
	decimal Price,
	Guid? TeacherId
);
