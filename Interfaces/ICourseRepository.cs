public interface ICourseRepository
{
    Task<CustomActionResult> CreateCourse(Course course);
    Task<CustomActionResult> EditCourse();
    Task<CustomActionResult> AddLesson(AddLessonDto lessonDto);
    CustomActionResult getAllCourses();
    Task<CustomActionResult> getCoursesByCategory(LearningCategory category);
}
