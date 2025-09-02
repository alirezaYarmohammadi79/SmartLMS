namespace SmartLMS.Application.Course.Command.SetFinalGradeCommand;

public record SetFinalGradeCommand(Guid CourseId, Guid StudentId, decimal Grade);
