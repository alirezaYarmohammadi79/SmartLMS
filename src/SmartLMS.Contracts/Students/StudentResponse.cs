namespace SmartLMS.Contracts.Students;

public record StudentResponse(
    string FirstName,
    string LastName,
    string Email,
    DateTime? DateOfBirth,
    string StudentStatus
);

