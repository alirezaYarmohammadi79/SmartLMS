namespace SmartLMS.Contracts.Courses;

public record CourseAdminReportResponse(
    Guid Id,
    string Title,
    int TotalEnrollments,
    int RemainingSeats,
    double AverageGrade
);
