namespace SmartLMS.Contracts.Courses;

public record RegisterStudentResponse(Guid CourseId, Guid StudentId, string Message);
