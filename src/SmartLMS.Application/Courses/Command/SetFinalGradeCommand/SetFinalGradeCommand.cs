namespace SmartLMS.Application.Courses.Command.SetFinalGradeCommand;

public record SetFinalGradeCommand(Guid CourseId, Guid StudentId, decimal Grade);
