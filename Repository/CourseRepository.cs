using Microsoft.EntityFrameworkCore;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IFileRepository _fileRepository;

    public CourseRepository(AppDbContext appDbContext, IFileRepository fileRepository)
    {
        _appDbContext = appDbContext;
        _fileRepository = fileRepository;
    }

    public async Task<CustomActionResult> AddLesson(AddLessonDto lessonDto)
    {
        var course = _appDbContext.Courses.SingleOrDefault(_ => _.Id == lessonDto.courseId);

        if (course == null)
        {
            return new CustomActionResult(new Result { ErrorMessage = new ErrorModel { ErrorMessage = "دوره ای با این ای دی یافت نشد" }, statusCodes = 404 });
        }

        var videoUrl = await _fileRepository.SaveFileAsync(lessonDto.video);
        if (course.price != null)
        {
            FileEncryption.EncryptFileWithKey("uploads/" + videoUrl, "uploads/" + videoUrl + ".bin", course.Id);
            _fileRepository.DeleteFile(videoUrl);
        }

        Lesson lesson = new Lesson { courseId = lessonDto.courseId, description = lessonDto.description, title = lessonDto.title, videoUrl = videoUrl + ".bin" };
        var createdLesson = await _appDbContext.Lessons.AddAsync(lesson);
        await _appDbContext.SaveChangesAsync();
        return new CustomActionResult(new Result { Data = new CustomData { message = "درس با موفقیت اضافه شد", data = createdLesson.Entity } });
    }

    public async Task<CustomActionResult> CreateCourse(Course course)
    {
        var createdCourse = await _appDbContext.Courses.AddAsync(course);
        await _appDbContext.SaveChangesAsync();
        return new CustomActionResult(new Result { Data = createdCourse });
    }

    public Task<CustomActionResult> EditCourse()
    {
        throw new NotImplementedException();
    }

    public async Task<CustomActionResult> getAllCourses()
    {
        var courses = await _appDbContext.Courses.Include(_ => _.lessons).ToListAsync();
        return new CustomActionResult(new Result { Data = courses });
    }

    public Task<CustomActionResult> getCoursesByCategory(LearningCategory category)
    {
        throw new NotImplementedException();
    }
}
