namespace SmartLMS.Contracts.Courses;

public sealed record SetFinalGradeResponse(Guid CourseId, Guid StudentId, decimal Grade, string Message);
