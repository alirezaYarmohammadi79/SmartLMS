namespace SmartLMS.Contracts.Courses.Requests;

public record CreateCourseRequest(
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    int Capacity,
    decimal Price,
    Guid? TeacherId
);
