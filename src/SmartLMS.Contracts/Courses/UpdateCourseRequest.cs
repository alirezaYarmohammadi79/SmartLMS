namespace SmartLMS.Contracts.Courses;

public record UpdateCourseRequest(
	Guid Id,
	string Title,
	string Description,
	DateTime StartDate,
	DateTime EndDate,
	int Capacity,
	decimal Price,
	Guid? TeacherId
);

