namespace SmartLMS.Contracts.Courses;

public record StudentCourseResponse(
    Guid Id,
    string Title,
    string TeacherName,
    DateTime EnrollmentDate,
    double? Grade
);