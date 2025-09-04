namespace SmartLMS.Contracts.Teachers;

public record CreateTeacherRequest(
    string FirstName,
    string LastName,
    string Email,
    string? Bio
);
