using Mapster;
using SmartLMS.Application.Teachers.Command.CreateTeacher;
using SmartLMS.Contracts.Teachers;
using SmartLMS.Domain.Teachers;

namespace SmartLMS.Api.Common.Mapping;

public class TeacherMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // ----------------------
        // Commands
        // ----------------------
        config.NewConfig<CreateTeacherRequest, CreateTeacherCommand>();

        // ----------------------
        // Queries
        // ----------------------

        config.NewConfig<Teacher,TeacherResponse>()
            .Map(dest => dest.FirstName , src=> src.FullName.FirstName)
            .Map(dest => dest.FamilyName, src=> src.FullName.LastName)
            .Map(dest => dest.Email, src=> src.Email.Value);
    }
}
