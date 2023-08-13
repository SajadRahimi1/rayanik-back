public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _appDbContext;

    public CourseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<CustomActionResult> AddLesson()
    {
        throw new NotImplementedException();
    }

    public async Task<CustomActionResult> CreateCourse(Course course)
    {
       var createdCourse =await _appDbContext.Courses.AddAsync(course);
       await _appDbContext.SaveChangesAsync();
       return new CustomActionResult(new Result{Data=createdCourse});
    }

    public Task<CustomActionResult> EditCourse()
    {
        throw new NotImplementedException();
    }

    public CustomActionResult getAllCourses()
    {
        var courses = _appDbContext.Courses.ToList();
        return new CustomActionResult(new Result { Data = courses });
    }

    public Task<CustomActionResult> getCoursesByCategory(LearningCategory category)
    {
        throw new NotImplementedException();
    }
}
