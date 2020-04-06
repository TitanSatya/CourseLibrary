using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibrary.API.Helpers;
using AutoMapper;
using CourseLibrary.API.Profiles;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private IMapper _Mapper;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
                                IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _Mapper = mapper;
        }


        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            
            return Ok(_Mapper.Map<IEnumerable<AuthorDTO>>(authorsFromRepo));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            
             
            return Ok(_Mapper.Map<AuthorDTO>(authorFromRepo));
        }
    }
}
