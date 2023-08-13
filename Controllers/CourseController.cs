using Microsoft.AspNetCore.Mvc;
using AutoMapper;


[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseController(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> createCourse(CreateCoursDto dto)
    {
        var course = _mapper.Map<Course>(dto);
        return await _courseRepository.CreateCourse(course);
    }
}
