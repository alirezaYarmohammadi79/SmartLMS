namespace SmartLMS.Application.Course.Query.GetCourseAdminReport;

public record CourseAdminReportDto(Guid CourseId ,
	string Title ,
	string TeacherName ,
	int Capacity, 
	int EnrolledCount ,
	int RemainCapacity , 
	double? AverageGrade);
