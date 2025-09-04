namespace SmartLMS.Contracts.Courses;

public record TeacherCourseResponse(
    Guid Id,
    string Title,
    int EnrollmentCount
);