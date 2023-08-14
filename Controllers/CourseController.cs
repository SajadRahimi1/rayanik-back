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

    [HttpGet]
    public async Task<IActionResult> getAllCourses()
    {
        return await _courseRepository.getAllCourses();
    }

    [HttpPost, Route("create")]
    public async Task<IActionResult> createCourse(CreateCoursDto dto)
    {
        var course = _mapper.Map<Course>(dto);
        return await _courseRepository.CreateCourse(course);
    }

    [HttpPost, Route("add-lesson")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(110 * 1024 * 1024)]
    public async Task<IActionResult> addLesson([FromForm] AddLessonDto dto)
    {
        return await _courseRepository.AddLesson(dto);
    }
}

