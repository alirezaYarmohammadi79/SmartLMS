
using SmartLMS.Application.Courses.Query.GetAvailableCoursesForStudent;
using SmartLMS.Application.Courses.Query.GetCourseAdminReport;
using SmartLMS.Application.Courses.Query.GetCourseStudents;
using SmartLMS.Application.Courses.Query.GetStudentCourses;
using SmartLMS.Application.Courses.Query.GetTeacherCourses;

namespace SmartLMS.Application.Common.Interfaces.ReadRepositories;

public interface ICourseReadRepository
{
	/// <summary>
	/// course reports for admin
	/// </summary>
	/// <returns></returns>
	Task<IReadOnlyList<CourseAdminReportDto>> GetCourseAdminReportsAsync();
	/// <summary>
	/// get list of available courses for student 
	/// </summary>
	/// <returns></returns>
	Task<IReadOnlyList<AvailableCoursesForStudentDto>> GetAvailableCoursesForStudentAsync();
	/// <summary>
	/// Retrieves a list of courses associated with the specified student.
	/// </summary>
	/// <param name="studentId">The unique identifier of the student whose courses are to be retrieved.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a read-only list of <see
	/// cref="StudentCourseDto"/> objects representing the student's courses. The list will be empty if the student is
	/// not enrolled in any courses.</returns>
	Task<IReadOnlyList<StudentCourseDto>> GetStudentCoursesAsync(Guid studentId);
	/// <summary>
	/// Asynchronously retrieves a list of courses associated with the specified teacher.
	/// </summary>
	/// <param name="teacherId">The unique identifier of the teacher whose courses are to be retrieved.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a read-only list of  <see
	/// cref="TeacherCourseDto"/> objects representing the courses associated with the specified teacher.  The list will
	/// be empty if the teacher has no associated courses.</returns>
	Task<IReadOnlyList<TeacherCourseDto>> GetTeacherCoursesAsync(Guid teacherId);
	/// <summary>
	/// Asynchronously retrieves a list of students enrolled in the specified course.
	/// </summary>
	/// <remarks>The returned list is read-only and reflects the state of enrolled students at the time of the
	/// method call.</remarks>
	/// <param name="courseId">The unique identifier of the course for which to retrieve enrolled students.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains a read-only list of <see
	/// cref="EnrolledStudentsDto"/> objects, each representing an enrolled student and their associated details.</returns>
	Task<IReadOnlyList<EnrolledStudentsDto>> GetEnrolledStudentsAsync(Guid courseId);
}
