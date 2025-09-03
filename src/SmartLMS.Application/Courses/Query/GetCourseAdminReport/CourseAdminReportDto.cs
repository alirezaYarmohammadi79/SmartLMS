namespace SmartLMS.Application.Courses.Query.GetCourseAdminReport;

public record CourseAdminReportDto(Guid CourseId ,
	string Title ,
	int EnrolledCount ,
	int RemainCapacity , 
	decimal? AverageGrade);
