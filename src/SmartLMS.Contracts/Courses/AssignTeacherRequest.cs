namespace SmartLMS.Contracts.Courses;

public record AssignTeacherRequest(
    Guid CourseId,
    Guid TeacherId
);

