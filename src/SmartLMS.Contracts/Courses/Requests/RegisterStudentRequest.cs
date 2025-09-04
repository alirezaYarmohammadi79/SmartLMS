namespace SmartLMS.Contracts.Courses.Requests;

public record RegisterStudentRequest(Guid CourseId, Guid StudentId);
