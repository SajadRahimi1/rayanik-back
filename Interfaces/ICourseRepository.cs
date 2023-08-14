public interface ICourseRepository
{
    Task<CustomActionResult> CreateCourse(CreateCoursDto courseDto);
    Task<CustomActionResult> EditCourse();
    Task<CustomActionResult> AddLesson(AddLessonDto lessonDto);
    Task<CustomActionResult> getAllCourses();
    Task<CustomActionResult> getCoursesByCategory(LearningCategory category);
}
