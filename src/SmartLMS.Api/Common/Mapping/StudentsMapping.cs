using Mapster;
using SmartLMS.Application.Students.Command.CreateStudent;
using SmartLMS.Contracts.Students;
using SmartLMS.Domain.Students;

namespace SmartLMS.Api.Common.Mapping;

public class StudentsMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // ----------------------
        // Commands
        // ----------------------
        config.NewConfig<CreateStudentRequest, CreateStudentCommand>();

        // ----------------------
        // Queries
        // ----------------------

        config.NewConfig<Student, StudentResponse>()
            .Map(dest => dest.FirstName, src => src.FullName.FirstName)
            .Map(dest => dest.LastName, src => src.FullName.LastName)
            .Map(dest => dest.Email, src => src.Email.Value)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth.Value);
    }
}
