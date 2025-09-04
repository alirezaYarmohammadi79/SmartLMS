namespace SmartLMS.Contracts.Courses;

public record EnrolledStudentsResponse(
    Guid StudentId,
    string FullName,
    string Email,
    double? Grade
);