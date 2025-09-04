namespace SmartLMS.Contracts.Courses;

public record AssignTeacherResponse(
    Guid CourseId,
    Guid TeacherId,
    string Message
);

