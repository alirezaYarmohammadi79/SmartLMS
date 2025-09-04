namespace SmartLMS.Contracts.Courses;

public sealed record SetFinalGradeRequest(Guid CourseId, Guid StudentId, decimal Grade);
