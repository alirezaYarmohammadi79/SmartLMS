using Mapster;
using SmartLMS.Application.Courses.Command.AssignTeacher;
using SmartLMS.Application.Courses.Command.CreateCourse;
using SmartLMS.Application.Courses.Command.RegisterStudent;
using SmartLMS.Application.Courses.Command.SetFinalGradeCommand;
using SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;
using SmartLMS.Application.Courses.Query.GetCourseAdminReport;
using SmartLMS.Application.Courses.Query.GetCourseStudents;
using SmartLMS.Application.Courses.Query.GetStudentCourses;
using SmartLMS.Application.Courses.Query.GetTeacherCourses;
using SmartLMS.Contracts.Courses;
using SmartLMS.Domain.Courses;

namespace SmartLMS.Api.Common.Mapping;

public class CourseMapping : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		// ----------------------
		// Commands
		// ----------------------

		config.NewConfig<CreateCourseRequest, CreateCourseCommand>();
        //config.NewConfig<UpdateCourseRequest, UpdateCourseCommand>();
        config.NewConfig<RegisterStudentRequest, RegisterStudentCommand>();
        config.NewConfig<SetFinalGradeRequest, SetFinalGradeCommand>();
        config.NewConfig<AssignTeacherRequest, AssignTeacherCommand>();

        // ----------------------
        // Queries
        // ----------------------

        config.NewConfig<Course, CourseResponse>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Title, src => src.Title.Value) 
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.StartDate, src => src.Period.Start)
			.Map(dest => dest.EndDate, src => src.Period.End)
			.Map(dest => dest.Capacity, src => src.Capacity.MaxSeats)
			.Map(dest => dest.RemainingSeats, src => src.RemainingSeats())
			.Map(dest => dest.Price, src => src.Price.Amount);

        config.NewConfig<CourseAdminReportDto, CourseAdminReportResponse>()
			.Map(dest => dest.Id , src=> src.CourseId)
			.Map(dest => dest.TotalEnrollments , src=> src.EnrolledCount)
			.Map(dest => dest.RemainingSeats , src=> src.RemainCapacity);

        config.NewConfig<AvailableCoursesForStudentDto, AvailableCoursesForStudentResponse>();
        config.NewConfig<StudentCourseDto, StudentCourseResponse>()
            .Map(dest => dest.Id, src => src.CourseId);

        config.NewConfig<TeacherCourseDto, TeacherCourseResponse>();
        config.NewConfig<EnrolledStudentsDto, EnrolledStudentsResponse>()
            .Map(dest => dest.FullName, src => src.StudentName)
            .Map(dest => dest.Email, src => src.StudentEmail);

        config.NewConfig<RegisterStudentCommand, RegisterStudentResponse>()
            .Map(dest => dest.CourseId, src => src.CourseId)
            .Map(dest => dest.StudentId, src => src.StudentId)
            .Map(dest => dest.Message, _ => "Student registered successfully.");

        config.NewConfig<SetFinalGradeCommand, SetFinalGradeResponse>()
            .Map(dest => dest.Message, _ => "Final grade assigned successfully.");

        config.NewConfig<AssignTeacherCommand, AssignTeacherResponse>()
            .Map(dest => dest.Message, _ => "Teacher was assigned successfully.");
    }
}
