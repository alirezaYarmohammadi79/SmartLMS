namespace SmartLMS.Contracts.Courses;

public record AvailableCoursesForStudentResponse(
    Guid Id,
    string Title,
    Guid TeacherId,
    string TeacherName,
    int RemainingSeats,
    DateTime StartDate,
    DateTime EndDate,
    decimal Price
);

