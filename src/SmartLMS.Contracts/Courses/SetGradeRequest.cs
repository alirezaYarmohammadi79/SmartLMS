namespace SmartLMS.Contracts.Courses;

public record SetGradeRequest(
	Guid StudentId,
	decimal Grade
);