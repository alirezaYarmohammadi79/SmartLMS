namespace SmartLMS.Contracts.Courses;

public record RegisterStudentRequest(Guid CourseId, Guid StudentId);
