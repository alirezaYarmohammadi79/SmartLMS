namespace SmartLMS.Contracts.Courses.Requests;

public sealed record SetFinalGradeRequest(Guid CourseId, Guid StudentId, decimal Grade);
