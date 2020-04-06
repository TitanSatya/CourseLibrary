using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Profiles;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private IMapper _Mapper;
        public CoursesController(ICourseLibraryRepository courseLibraryRepository,
                                IMapper mapper)
        {
              _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _Mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetCoursesForAuthors(Guid authorId)
        {
            if(!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var courseForAuthors = _courseLibraryRepository.GetCourses(authorId);
            return Ok(_Mapper.Map<IEnumerable<CourseDTO>>(courseForAuthors));
        }
    }
}