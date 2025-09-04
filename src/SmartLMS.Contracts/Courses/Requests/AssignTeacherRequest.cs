namespace SmartLMS.Contracts.Courses.Requests;

public record AssignTeacherRequest(
    Guid CourseId,
    Guid TeacherId
);

