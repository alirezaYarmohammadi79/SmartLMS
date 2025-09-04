using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Domain.Courses.Events;
using SmartLMS.Domain.Courses.ValueObjects;
using SmartLMS.Domain.Courses;
using FluentAssertions;

namespace SmartLMS.Domain.UnitTests.Courses;

public class CourseTests
{
    private static CourseTitle SampleTitle => new CourseTitle("DDD Fundamentals");
    private static DateRange ActivePeriod => new DateRange(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(10));
    private static DateRange ExpiredPeriod => new DateRange(DateTime.UtcNow.AddDays(-10), DateTime.UtcNow.AddDays(-1));
    private static Capacity Capacity10 => new Capacity(10);
    private static Price PriceFree => new Price(0);

    [Fact]
    public void AssignTeacher_ShouldSetTeacherId_WhenNoTeacherAssigned()
    {
        var course = BuildSampleCourse();

        var teacherId = Guid.NewGuid();
        course.AssignTeacher(teacherId);

        course.TeacherId.Should().Be(teacherId);
    }

    [Fact]
    public void AssignTeacher_SameTeacherTwice_ShouldThrow()
    {
        var course = BuildSampleCourse();
        var teacherId = Guid.NewGuid();
        course.AssignTeacher(teacherId);

        Action act = () => course.AssignTeacher(teacherId);

        act.Should().Throw<TeacherAlreadyAssignedException>();
    }

    [Fact]
    public void EnrollStudent_ShouldAddEnrollment_AndRaiseDomainEvent()
    {
        var course = BuildSampleCourse();
        var studentId = Guid.NewGuid();

        course.EnrollStudent(studentId);

        course.Enrollments.Should().ContainSingle(e => e.StudentId == studentId);
        course.DomainEvents
            .OfType<StudentEnrolled>()
            .Should()
            .Contain(se => se.StudentId == studentId);
    }

    [Fact]
    public void EnrollStudent_WhenFull_ShouldThrow()
    {
        var course = Course.Create(SampleTitle, "Desc", ActivePeriod, new Capacity(1), PriceFree, null);
        course.EnrollStudent(Guid.NewGuid());

        Action act = () => course.EnrollStudent(Guid.NewGuid());

        act.Should().Throw<CourseFullException>();
    }

    [Fact]
    public void EnrollStudent_WhenAlreadyEnrolled_ShouldThrow()
    {
        var course = BuildSampleCourse();
        var studentId = Guid.NewGuid();
        course.EnrollStudent(studentId);

        Action act = () => course.EnrollStudent(studentId);

        act.Should().Throw<StudentAlreadyEnrolledException>();
    }

    [Fact]
    public void EnrollStudent_WhenOutsidePeriod_ShouldThrow()
    {
        var course = Course.Create(SampleTitle, "Desc", ExpiredPeriod, Capacity10, PriceFree, null);

        Action act = () => course.EnrollStudent(Guid.NewGuid());

        act.Should().Throw<CourseEnrollmentClosedException>();
    }

    [Fact]
    public void RemoveStudent_ShouldRemoveEnrollment_AndRaiseDomainEvent()
    {
        var course = BuildSampleCourse();
        var studentId = Guid.NewGuid();
        course.EnrollStudent(studentId);

        course.RemoveStudent(studentId);

        course.Enrollments.Should().BeEmpty();
        course.DomainEvents
            .OfType<StudentRemoved>()
            .Should()
            .Contain(sr => sr.StudentId == studentId);
    }

    [Fact]
    public void RemoveStudent_WhenNotEnrolled_ShouldThrow()
    {
        var course = BuildSampleCourse();
        var studentId = Guid.NewGuid();

        Action act = () => course.RemoveStudent(studentId);

        act.Should().Throw<StudentNotEnrolledException>();
    }  

    [Fact]
    public void AssignGrade_BeforeCourseEnds_ShouldThrow()
    {
        var course = BuildSampleCourse();
        var studentId = Guid.NewGuid();
        course.EnrollStudent(studentId);

        Action act = () => course.AssignGrade(studentId, 90m);

        act.Should().Throw<CannotAssignGradeBeforeCourseEndsException>();
    }

    [Fact]
    public void AssignGrade_WhenStudentNotEnrolled_ShouldThrow()
    {
        var period = new DateRange(DateTime.UtcNow.AddDays(-10), DateTime.UtcNow.AddDays(-5));
        var course = Course.Create(SampleTitle, "Desc", period, Capacity10, PriceFree, null);

        Action act = () => course.AssignGrade(Guid.NewGuid(), 80m);

        act.Should().Throw<StudentNotEnrolledException>();
    }

    [Fact]
    public void RemainingSeats_ShouldReturnCorrectValue()
    {
        var course = BuildSampleCourse();
        var studentId = Guid.NewGuid();
        course.EnrollStudent(studentId);

        course.RemainingSeats().Should().Be(Capacity10.MaxSeats - 1);
    }

    private static Course BuildSampleCourse()
    {
        return Course.Create(SampleTitle, "Desc", ActivePeriod, Capacity10, PriceFree, null);
    }
}
