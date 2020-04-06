
using CourseLibrary.API.Helpers;
namespace CourseLibrary.API.Profiles
{
    public class CoursesProfile : AutoMapper.Profile
    {
        public CoursesProfile()
        {
            CreateMap<Entities.Course, Models.CourseDTO>();


        }
    }
}