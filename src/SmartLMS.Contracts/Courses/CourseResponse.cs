namespace SmartLMS.Contracts.Courses;

public record CourseResponse(Guid Id,
	string Title,
	string Description,
	DateTime StartDate,
	DateTime EndDate,
	int Capacity,
	decimal Price,
	int RemainingSeats,
	Guid TeacherId);

