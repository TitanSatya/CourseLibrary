
using CourseLibrary.API.Helpers;
namespace CourseLibrary.API.Profiles
{
    public class AuthorProfile : AutoMapper.Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDTO>()
            .ForMember(
                forMember => forMember.Name,
                output => output.MapFrom(sourceMember => $"{sourceMember.FirstName} {sourceMember.LastName}")
            )
            .ForMember(
                forMember => forMember.Age,
                output => output.MapFrom(sourceMember => sourceMember.DateOfBirth.GetCurrrentAge())
                 
            );

        }
    }
}