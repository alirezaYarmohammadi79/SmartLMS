namespace SmartLMS.Contracts.Students;

public record CreateStudentRequest(
     string FirstName,
 string LastName,
 string Email,
 DateTime? DateOfBirth
    );

